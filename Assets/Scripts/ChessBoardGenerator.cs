using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChessBoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
       [SerializeField] private Color lightColor = Color.white;
       [SerializeField] private Color darkColor = new Color(0.0f, 0.0f, 0.0f);
       [SerializeField] private GameObject itemPrefab;
       [SerializeField] private ChessPieceSet pieceSet;
       private const int BOARD_SIZE = 8;
       private GameObject[,] _boardSlots =  new GameObject[BOARD_SIZE, BOARD_SIZE];
       private bool _isWhiteView = true;
       void Start()
       {
           transform.localRotation = Quaternion.identity;
           GenerateBoard();
           StartGenerateFigure();
       }
    
       void GenerateBoard()
       {
           GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
           grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
           grid.constraintCount = BOARD_SIZE;
           
           foreach (Transform child in transform)
           {
               Destroy(child.gameObject);
           }

           for (int y = 0; y < BOARD_SIZE; y++)
           {
               for (int x = 0; x < BOARD_SIZE; x++)
               {
                   GameObject slot = Instantiate(slotPrefab, transform);
                   slot.name = $"Slot_{x}_{y}";
                   _boardSlots[x, y] = slot;
                   Image slotImage = slot.GetComponent<Image>();
                   slotImage.enabled = true;
                   bool isLightSquare = (x + y) % 2 == 0;
                   slotImage.color = isLightSquare ? lightColor : darkColor;
               }
           }
       }

       public string GetSlot(int x, int y)
       {
           return _boardSlots[x, y].name;
       }
       public GameObject GetCurrentSlot(Transform slot,int count)
       {
           Debug.Log(count);
           for (int y = 0; y < BOARD_SIZE; y++)
           {
               for (int x = 0; x < BOARD_SIZE; x++)
               {
                   if (_boardSlots[x,y].name == slot.name)
                   {
                       return _boardSlots[x,y+count];
                   }
               }
               
           }
           return _boardSlots[0, 0];
       }
       public void StartGenerateFigure()
       {
           for (int x = 0; x < BOARD_SIZE; x++)
           {
               CreateItemAt(x,1,PieceType.Pawn,PieceColor.Black);
               CreateItemAt(x,6,PieceType.Pawn,PieceColor.White);
           }
           
           CreateItemAt(7, 7,PieceType.Rook,PieceColor.White);
           CreateItemAt(0, 7,PieceType.Rook,PieceColor.White);
           
           CreateItemAt(0,0,PieceType.Rook,PieceColor.Black);
           CreateItemAt(7, 0,PieceType.Rook,PieceColor.Black);
           
           CreateItemAt(1, 7,PieceType.Knight,PieceColor.White);
           CreateItemAt(6, 7,PieceType.Knight,PieceColor.White);
           
           CreateItemAt(1, 0,PieceType.Knight,PieceColor.Black);
           CreateItemAt(6, 0,PieceType.Knight,PieceColor.Black);
           
           CreateItemAt(2, 7,PieceType.Bishop,PieceColor.White);
           CreateItemAt(5, 7,PieceType.Bishop,PieceColor.White);
           
           CreateItemAt(2, 0,PieceType.Bishop,PieceColor.Black);
           CreateItemAt(5, 0,PieceType.Bishop,PieceColor.Black);
           
           CreateItemAt(3, 7,PieceType.Queen,PieceColor.White);
           CreateItemAt(3, 0,PieceType.Queen,PieceColor.Black);
           
           CreateItemAt(4, 7,PieceType.King,PieceColor.White);
           CreateItemAt(4, 0,PieceType.King,PieceColor.Black);
       }

       void CreateItemAt(int x, int y,PieceType type, PieceColor color)
       {
           Vector2Int v = ViewToBoard(x, y);
           GameObject go = Instantiate(itemPrefab, _boardSlots[v.x, v.y].transform, false);
           ChessPiece piece = go.GetComponent<ChessPiece>();
           piece.Init(type, color, pieceSet);
       }
       Vector2Int ViewToBoard(int x, int y)
       {
           if (_isWhiteView)
               return new Vector2Int(x, y);

           return new Vector2Int(7 - x, 7 - y);
       }
       
       public void FlipBoard()
       {
           _isWhiteView = !_isWhiteView;
           
           foreach (var slot in _boardSlots)
           {
               foreach (Transform piece in slot.transform)
               {
                   Destroy(piece.gameObject);
               }
           }

           StartGenerateFigure();
       }
}
