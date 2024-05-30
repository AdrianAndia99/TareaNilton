using System.Collections;
using UnityEngine;
public class EnemyControl : MonoBehaviour
{
    private Edge currentEdge;
    public Edge CurrentEdge
    {
        get
        {
            return currentEdge;
        }
        set
        {
            currentEdge = value;
        }
    }
    public Vector2 speedReference;
    public float energy;
    public float maxEnergy;
    public float restTime;
    private bool isResting = false;
    private void Update()
    {
        if (isResting == false)
        {
            transform.position = Vector2.SmoothDamp(transform.position, currentEdge.NodeB.transform.position, ref speedReference, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            NodeControl currentNode = collision.gameObject.GetComponent<NodeControl>();
            if (currentNode == currentEdge.NodeB)
            {
                Debug.Log(currentEdge.Weight);
                energy = energy - currentEdge.Weight;
                if (energy <= 0)
                {
                    StartCoroutine(Rest());
                }
                else
                {
                    currentEdge = currentNode.SelectRandomOutgoing(currentNode);
                    NodeControl nextNode;
                    if (currentEdge.NodeA == currentNode)
                    {
                        nextNode = currentEdge.NodeB;
                    }
                    else
                    {
                        nextNode = currentEdge.NodeA;
                    }
                    currentEdge.NodeB = nextNode;
                }
            }
        }
    }
    IEnumerator Rest()
    {
        isResting = true;
        yield return new WaitForSeconds(restTime);
        energy = maxEnergy;
        NodeControl currentNode = currentEdge.NodeB;
        currentEdge = currentNode.SelectRandomOutgoing(currentNode);
        NodeControl nextNode;
        if (currentEdge.NodeA == currentNode)
        {
            nextNode = currentEdge.NodeB;
        }
        else
        {
            nextNode = currentEdge.NodeA;
        }
        currentEdge.NodeB = nextNode;
        isResting = false;
    }
}
