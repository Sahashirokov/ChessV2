using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour,IDropHandler
{
    void Awake()
    {
        this.enabled = true;
        GetComponent<GridLayoutGroup>().enabled = true;
    }
    public void OnDrop(PointerEventData eventData)
    { 
        Debug.Log("OnDrop");
        
        var figure = eventData.pointerDrag?.GetComponent<Figure>();
        if (figure == null) return;
        GameController.Instance.OnFigureDropped(figure, this);
        // GameObject dropped = eventData.pointerDrag;
        // Figure figure = dropped.GetComponent<Figure>();
        // figure._startItem = transform;
         // var otherItemTransform = eventData.pointerDrag.transform;
         // otherItemTransform.SetParent(transform);
         // otherItemTransform.localPosition = Vector3.zero;
    }
    
}
