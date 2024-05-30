using UnityEngine;

public class NodeControl : MonoBehaviour
{
    private ListaSimpleEnlazada<Edge> outgoingEdges = new ListaSimpleEnlazada<Edge>(); // Aristas salientes

    public void AddOutgoingEdge(Edge edge)
    {
        outgoingEdges.InsertarNodoAlFinal(edge);
    }

    public Edge SelectRandomOutgoing(NodeControl currentNode)
    {
        ListaSimpleEnlazada<Edge> validEdges = new ListaSimpleEnlazada<Edge>();
        for (int i = 0; i < outgoingEdges.longitud; i++)
        {
            Edge edge = outgoingEdges.ObtenerNodoPorPosicion(i);
            if (edge.NodeA == currentNode)
            {
                validEdges.InsertarNodoAlFinal(edge);
            }
        }

        if (validEdges.longitud == 0)
        {
            Debug.Log("No hay aristas salientes válidas desde el nodo actual.");
            return null; // O manejar de otra manera si es necesario
        }

        int index = Random.Range(0, validEdges.longitud);
        Edge selectedEdge = validEdges.ObtenerNodoPorPosicion(index);

        // Asegúrate de que el nodo de destino no sea el mismo que el nodo actual
        while (selectedEdge.NodeB == currentNode)
        {
            index = Random.Range(0, validEdges.longitud);
            selectedEdge = validEdges.ObtenerNodoPorPosicion(index);
        }

        return selectedEdge;
    }
}

