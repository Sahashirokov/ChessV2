using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour,IDropHandler
{
    [SerializeField] private GameObject _knobprefab;
    
    void Awake()
    {
        this.enabled = true;
        GetComponent<GridLayoutGroup>().enabled = true;
        transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
    }
    public void OnDrop(PointerEventData eventData)
    { 
        var figure = eventData.pointerDrag?.GetComponent<Figure>();
        if (figure == null) return;
        GameController.Instance.OnFigureDropped(figure, this);
    }

    public void Hightlight()
    {
        Debug.Log($"name Cell:{name}");
      
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HideHightlight()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
