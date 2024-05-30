using UnityEngine;

public class UIManagerController : MonoBehaviour
{
    public static UIManagerController Instance { get; private set; }
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject ui;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void ActiveGameWindow()
    {
        game.SetActive(true);
    }
    public void DisableGameWindow()
    {
        game.SetActive(false);
    }
    public void ActiveOptionsWindow()
    {
        options.SetActive(true);
    }
    public void DisableOptionsWindow()
    {
        options.SetActive(false);
    }
    public void ActiveCreditsWindow()
    {
        credits.SetActive(true);
    }
    public void DisableCreditsWindow()
    {
        credits.SetActive(false);
    }
    public void DisableUI()
    {
        ui.SetActive(false);
    }
    public void ActiveUI()
    {
        ui.SetActive(true);
    }
}

