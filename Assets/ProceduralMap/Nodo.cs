using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grafo
{
    public List<Nodo> Nodos;

    public Grafo()
    {
        Nodos = new List<Nodo>();
    }

    public void AddNode(Nodo nodo)
    {
        Nodos.Add(nodo);
    }

    public void ConnectNodes()
    {
        for (int i = 0; i < Nodos.Count - 1; i++)
        {
            Nodos[i].Siguiente = Nodos[i + 1];
        }
        if (Nodos.Count > 1)
        {
            Nodos[Nodos.Count - 1].Siguiente = Nodos[0];
        }
    }

    public bool IsClosed()
    {
        if (Nodos.Count > 1)
        {
            return Nodos[Nodos.Count - 1].Siguiente == Nodos[0];
        }
        return false;
    }
}

public class Nodo
{
    public int Id;
    public Vector2 Position; // Para la posición gráfica del nodo
    public Nodo Siguiente;   // Para la conexión en el circuito

    public Nodo(int id, Vector2 position)
    {
        Id = id;
        Position = position;
    }
}
public static class ListExtensions
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
