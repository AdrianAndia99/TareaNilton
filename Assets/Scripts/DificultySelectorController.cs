using UnityEngine;
using UnityEngine.Events;
public class DificultySelectorController : MonoBehaviour
{
    public UnityEvent assingButtons;
    DoubleLinkedCircularList<GameObject> buttons = new DoubleLinkedCircularList<GameObject>();
    private GameObject currentButton;
    private int current;
    private void Awake()
    {
        assingButtons?.Invoke();

    }
    private void Start()
    {
        currentButton = buttons.GetNodeAtPosition(0);
    }
    public void AddButton(GameObject button)
    {
        buttons.InsertNodeAtEnd(button);
    }
    public void NextButton()
    {

    }
    public void SelectDifficulty()
    {
        UIManagerController.Instance.DisableUI();
    }
}
