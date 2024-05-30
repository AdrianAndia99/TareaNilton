public class Edge
{
    public NodeControl NodeA { get; set; }
    public NodeControl NodeB { get; set; }
    public float Weight { get; set; }

    public Edge(NodeControl nodeA, NodeControl nodeB, float weight)
    {
        NodeA = nodeA;
        NodeB = nodeB;
        Weight = weight;
    }
}
