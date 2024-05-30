using System;
public class ListaSimpleEnlazada<T>
{
    Nodo Cabeza;
    public int longitud = 0;
    class Nodo
    {
        public T Valor { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo(T valor)
        {
            this.Valor = valor;
            Siguiente = null;
        }
    }
    public void InsertarNodoAlInicio(T valor)
    {
        if (Cabeza == null)
        {
            Nodo nuevoNodo = new Nodo(valor);
            Cabeza = nuevoNodo;
            longitud = longitud + 1;
        }
        else
        {
            Nodo nuevoNodo = new Nodo(valor);
            nuevoNodo.Siguiente = Cabeza;
            Cabeza = nuevoNodo;
            longitud = longitud + 1;
        }
    }
    public void InsertarNodoAlFinal(T valor)
    {
        if (Cabeza == null)
        {
            InsertarNodoAlInicio(valor);
        }
        else
        {
            Nodo ultimo = Cabeza;
            while (ultimo.Siguiente != null)
            {
                ultimo = ultimo.Siguiente;
            }
            Nodo nuevoNodo = new Nodo(valor);
            ultimo.Siguiente = nuevoNodo;
            longitud = longitud + 1;
        }
    }
    public void InsertarNodoPorPosicion(T valor, int posicion)
    {
        if (posicion == 0)
        {
            InsertarNodoAlInicio(valor);
        }
        else if (posicion == longitud - 1)
        {
            InsertarNodoAlFinal(valor);
        }
        else if (posicion >= longitud)
        {
            throw new Exception("El valor introduccido va mas alla de la longitud de la lista");
        }
        else
        {
            Nodo anterior = Cabeza;
            int iterador = 0;
            while (iterador < posicion - 1)
            {
                anterior = anterior.Siguiente;
                iterador = iterador + 1;
            }
            Nodo siguiente = anterior.Siguiente;
            Nodo nuevoNodo = new Nodo(valor);
            anterior.Siguiente = nuevoNodo;
            nuevoNodo.Siguiente = siguiente;
            longitud = longitud + 1;
        }
    }
    public void ModificarAlInicio(T valor)
    {
        if (Cabeza == null)
        {
            throw new Exception("No existe ningun nodo.");
        }
        else
        {
            Cabeza.Valor = valor;
        }
    }
    public void ModificarAlFinal(T valor)
    {
        if (Cabeza == null)
        {
            ModificarAlInicio(valor);
        }
        else
        {
            Nodo ultimo = Cabeza;
            while (ultimo.Siguiente != null)
            {
                ultimo = ultimo.Siguiente;
            }
            ultimo.Valor = valor;
        }
    }
    public void ModificarNodoPorPosicion(T valor, int posicion)
    {
        if (posicion == 0)
        {
            ModificarAlInicio(valor);
        }
        else if (posicion == longitud - 1)
        {
            ModificarAlFinal(valor);
        }
        else if (posicion >= longitud)
        {
            throw new Exception("No existe esa posicion en la lista");
        }
        else
        {
            Nodo nodoPosicion = Cabeza;
            int iterador = 0;
            while (iterador < posicion)
            {
                nodoPosicion = nodoPosicion.Siguiente;
                iterador = iterador + 1;
            }
            nodoPosicion.Valor = valor;
        }
    }
    public T ObtenerNodoDelInicio()
    {
        if (Cabeza == null)
        {
            throw new Exception("La lista esta vacia");
        }
        else
        {
            return Cabeza.Valor;
        }
    }
    public T ObtenerNodoDelFinal()
    {
        if (Cabeza == null)
        {
            return ObtenerNodoDelInicio();
        }
        else
        {
            Nodo ultimo = Cabeza;
            while (ultimo.Siguiente != null)
            {
                ultimo = ultimo.Siguiente;
            }
            return ultimo.Valor;
        }
    }
    public T ObtenerNodoPorPosicion(int posicion)
    {
        if (posicion == 0)
        {
            return ObtenerNodoDelInicio();
        }
        else if (posicion == longitud - 1)
        {
            return ObtenerNodoDelFinal();
        }
        else if (posicion >= longitud)
        {
            throw new Exception("El valor introduccido va mas alla de la longitud de la lista");
        }
        else
        {
            Nodo nodoPosicion = Cabeza;
            int iterador = 0;
            while (iterador < posicion)
            {
                nodoPosicion = nodoPosicion.Siguiente;
                iterador = iterador + 1;
            }
            return nodoPosicion.Valor;
        }
    }
    public void EliminarAlInicio()
    {
        if (Cabeza == null)
        {
            throw new Exception("No hay elementos en la lista");
        }
        else
        {
            Nodo nuevaCabeza = Cabeza.Siguiente;
            Cabeza.Siguiente = null;
            Cabeza = nuevaCabeza;
            longitud = longitud - 1;
        }
    }
    public void EliminarAlFinal()
    {
        if (Cabeza == null)
        {
            EliminarAlInicio();
        }
        else
        {
            Nodo anteriorDelUltimoNodo = Cabeza;
            while (anteriorDelUltimoNodo.Siguiente.Siguiente != null)
            {
                anteriorDelUltimoNodo = anteriorDelUltimoNodo.Siguiente;
            }
            Nodo ultimoNodo = anteriorDelUltimoNodo.Siguiente;
            ultimoNodo = null;
            anteriorDelUltimoNodo.Siguiente = null;
            longitud = longitud - 1;
        }
    }
    public void EliminarNodoPorPosicion(int posicion)
    {
        if (posicion == 0)
        {
            EliminarAlInicio();
        }
        else if (posicion == longitud - 1)
        {
            EliminarAlFinal();
        }
        else if (posicion >= longitud)
        {
            throw new Exception("El valor introduccido va mas alla de la longitud de la lista");
        }
        else
        {
            Nodo anterior = Cabeza;
            int iterador = 0;
            while (iterador < posicion - 1)
            {
                anterior = anterior.Siguiente;
                iterador = iterador + 1;
            }
            Nodo siguiente = anterior.Siguiente.Siguiente;
            Nodo nodoPosicion = anterior.Siguiente;
            nodoPosicion.Siguiente = null;
            nodoPosicion = null;
            anterior.Siguiente = null;
            anterior.Siguiente = siguiente;
            longitud = longitud - 1;
        }
    }
}
