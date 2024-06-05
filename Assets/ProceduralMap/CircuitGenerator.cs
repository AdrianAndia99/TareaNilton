using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitGenerator : MonoBehaviour
{
    public int numeroDeNodosPorLado = 4;
    public float distanciaEntreNodos = 1.0f; 

    public GameObject prefabNodo;  

    public Sprite[] tilesetSprites;

    private Grafo grafo;
    private List<Vector2> posicionesOcupadas = new List<Vector2>();

    void Start()
    {
        if (prefabNodo == null || tilesetSprites == null || tilesetSprites.Length == 0)
        {
            Debug.LogError("Uno o más componentes no están asignados en el Inspector.");
            return;
        }

        grafo = new Grafo();
        GenerarCuadrado();
    }

    void GenerarCuadrado()
    {
        Vector2 posicionActual = Vector2.zero;
        posicionesOcupadas.Add(posicionActual);

        Nodo nodoInicial = new Nodo(0, posicionActual);
        grafo.AddNode(nodoInicial);

        for (int i = 1; i < numeroDeNodosPorLado; i++)
        {
            Vector2 nuevaPosicion = new Vector2(posicionActual.x + distanciaEntreNodos, posicionActual.y);
            AgregarNodo(nuevaPosicion);
            posicionActual = nuevaPosicion;
        }

        for (int i = 1; i < numeroDeNodosPorLado; i++)
        {
            Vector2 nuevaPosicion = new Vector2(posicionActual.x, posicionActual.y + distanciaEntreNodos);
            AgregarNodo(nuevaPosicion);
            posicionActual = nuevaPosicion;
        }

        for (int i = 1; i < numeroDeNodosPorLado; i++)
        {
            Vector2 nuevaPosicion = new Vector2(posicionActual.x - distanciaEntreNodos, posicionActual.y);
            AgregarNodo(nuevaPosicion);
            posicionActual = nuevaPosicion;
        }

        for (int i = 1; i < numeroDeNodosPorLado; i++)
        {
            Vector2 nuevaPosicion = new Vector2(posicionActual.x, posicionActual.y - distanciaEntreNodos);
            AgregarNodo(nuevaPosicion);
            posicionActual = nuevaPosicion;
        }

        grafo.ConnectNodes();

        // Instanciar conexiones entre nodos
        for (int i = 0; i < grafo.Nodos.Count; i++)
        {
            Vector2 inicio = grafo.Nodos[i].Position;
            Vector2 fin = grafo.Nodos[(i + 1) % grafo.Nodos.Count].Position;
            CrearConexionVisual(inicio, fin);
        }
    }

    void AgregarNodo(Vector2 posicion)
    {
        Nodo nodo = new Nodo(grafo.Nodos.Count, posicion);
        grafo.AddNode(nodo);
        posicionesOcupadas.Add(posicion);

        GameObject nodoObj = Instantiate(prefabNodo, posicion, Quaternion.identity);
        NodeVisual nodoVisual = nodoObj.GetComponent<NodeVisual>();

        if (nodoVisual == null)
        {
            Debug.LogError("El prefab de nodo no tiene el componente NodeVisual.");
            return;
        }

        nodoVisual.tilesetSprites = tilesetSprites; 
        nodoVisual.AssignRandomSprite();
    }

    void CrearConexionVisual(Vector2 inicio, Vector2 fin)
    {
        Vector2 direccion = (fin - inicio).normalized;
        float distancia = Vector2.Distance(inicio, fin);

        Vector2 posicionMedia = (inicio + fin) / 2;
        GameObject conector = Instantiate(prefabNodo, posicionMedia, Quaternion.identity);
        conector.transform.right = direccion;

        SpriteRenderer spriteRenderer = conector.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.drawMode = SpriteDrawMode.Sliced; 
            spriteRenderer.size = new Vector2(distancia, 1);
            conector.transform.localScale = new Vector3(1, 1, 1); 
        }
    }
}
