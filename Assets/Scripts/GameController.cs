using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool CanMove(Figure figure, Cell targetCell)
    {
      // figure.GetFigure();
        return true;
    }

    public void OnFigureDropped(Figure figure, Cell cell)
    {
        
        if (CanMove(figure, cell))
        {
            figure.MoveTo(cell.transform);
        }
        else
        {
            figure.ReturnToStart();
        }
    }
}
