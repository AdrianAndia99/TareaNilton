using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SOitem> items = new List<SOitem>();
    private Stack<SOitem> itemStack = new Stack<SOitem>();
    private SOitem _currentItem;
    private bool isEffectActive = false;

    public SOitem currentItem
    {
        get { return _currentItem; }
    }

    void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            itemStack.Push(items[i]);
        }

        if (itemStack.Count > 0)
        {
            _currentItem = itemStack.Pop();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isEffectActive && _currentItem != null)
        {
            StartCoroutine(ActivateCurrentItemEffect());
        }
    }

    private IEnumerator<WaitForSeconds> ActivateCurrentItemEffect()
    {
        isEffectActive = true;
        _currentItem.ActivateEffect();
        yield return new WaitForSeconds(_currentItem.duration);

        if (itemStack.Count > 0)
        {
            _currentItem = itemStack.Pop();
        }
        else
        {
            _currentItem = null;
        }

        isEffectActive = false;
    }
}