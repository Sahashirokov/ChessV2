using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class Figure : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Canvas _mainCanvas;
    private RectTransform _rectTransform;
    private Transform _startItem;
    private Transform _targetCell;
    private CanvasGroup _canvasGroup;
   private GameObject _cacheprefab;
    void Awake()
    {
       enabled = true;
    }
    public void MoveTo(Transform cell)
    {
        _targetCell = cell;
    }

    public void ReturnToStart()
    {
        _targetCell = _startItem;
    }
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas= GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        GetComponent<Image>().enabled = true;
       _canvasGroup.enabled = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(1))
        {
            this.gameObject.SetActive(false);
        }
        _startItem = transform.parent;
        _targetCell = null; 
        transform.SetParent(_mainCanvas.transform);
        transform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
        GetFigure();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Transform finalParent = _targetCell != null ? _targetCell : _startItem;

        transform.SetParent(finalParent);
        _rectTransform.localPosition = Vector3.zero;
       _canvasGroup.blocksRaycasts = true;
       _cacheprefab.GetComponent<Cell>().HideHightlight();
    }
    
    public void GetFigure()
    {
       var color = GetComponent<ChessPiece>().Color;
       var type= GetComponent<ChessPiece>().Type;
       int dir = color == PieceColor.White ? -1:1;
       
     //получили объект
         _cacheprefab = _startItem.GetComponentInParent<ChessBoardGenerator>().GetCurrentSlot(_startItem,dir);
     _cacheprefab.GetComponent<Cell>().Hightlight();
         Debug.Log($" GameObject name Cell:{_cacheprefab.name}");
    }
}
