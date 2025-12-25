using UnityEngine;

public class SettingBoard : MonoBehaviour
{
  public void RotateBoard()
   {
       GetComponent<ChessBoardGenerator>().FlipBoard();
   }
}
