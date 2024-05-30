using UnityEngine;
public class GraphControl : MonoBehaviour
{
    public GameObject nodePrefab;
    public TextAsset nodePositionsTxt;
    public string[] arrayNodePositions;
    public string[] currentNodePositions;
    public ListaSimpleEnlazada<GameObject> allNodes = new ListaSimpleEnlazada<GameObject>();
    public TextAsset nodeConectionsTxt;
    public string[] arrayNodeConections;
    public string[] currentNodeConections;
    public EnemyControl enemy;
    private void Start()
    {
        CreateNodes();
        CreateConnections();
        SelectInitialNode();
    }
    void CreateNodes()
    {
        if (nodePositionsTxt != null)
        {
            arrayNodePositions = nodePositionsTxt.text.Split('\n');
            for (int i = 0; i < arrayNodePositions.Length; ++i)
            {
                currentNodePositions = arrayNodePositions[i].Split(',');
                Vector2 position = new Vector2(float.Parse(currentNodePositions[0]), float.Parse(currentNodePositions[1]));
                GameObject tmp = Instantiate(nodePrefab, position, transform.rotation);
                allNodes.InsertarNodoAlFinal(tmp);

            }
        }
    }
    void CreateConnections()
    {
        if (nodeConectionsTxt != null)
        {
            arrayNodeConections = nodeConectionsTxt.text.Split('\n');
            for (int i = 0; i < arrayNodeConections.Length; ++i)
            {
                currentNodeConections = arrayNodeConections[i].Split(",");
                for (int j = 0; j < currentNodeConections.Length - 1; ++j) 
                {
                    NodeControl node1 = allNodes.ObtenerNodoPorPosicion(i).GetComponent<NodeControl>();
                    NodeControl node2 = allNodes.ObtenerNodoPorPosicion(int.Parse(currentNodeConections[j])).GetComponent<NodeControl>();
                    float weight = float.Parse(currentNodeConections[currentNodeConections.Length - 1]);
                    Edge edge = new Edge(node1, node2, weight);
                    node1.AddOutgoingEdge(edge);
                }
            }
        }
    }
    void SelectInitialNode()
    {
        int index = Random.Range(0, allNodes.longitud);
        NodeControl initialNode = allNodes.ObtenerNodoPorPosicion(index).GetComponent<NodeControl>();
        Edge initialEdge = initialNode.SelectRandomOutgoing(initialNode);
        enemy.CurrentEdge = initialEdge;
    }

}
