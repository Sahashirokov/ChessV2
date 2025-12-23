using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChessBoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
       [SerializeField] private Color lightColor = Color.white;
       [SerializeField] private Color darkColor = new Color(0.0f, 0.0f, 0.0f);
       
       private const int BOARD_SIZE = 8;

       void Start()
       {
           GenerateBoard();
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
           
           for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
           {
               int x = i % BOARD_SIZE;
               int y = i / BOARD_SIZE;
               
               GameObject slot = Instantiate(slotPrefab, transform);
               slot.name = $"Slot_{x}_{y}";
               
               Image slotImage = slot.GetComponent<Image>();
               
               if (slotImage == null)
               {
                   Debug.LogError("Нет компонента Image!");
                   return;
               }
               slotImage.enabled = true;
               if (slotImage != null)
               {
                   bool isLightSquare = (x + y) % 2 == 0;
                   slotImage.color = isLightSquare ? lightColor : darkColor;
               }
               
           }
       }
}
