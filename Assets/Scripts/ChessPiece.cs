using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public enum PieceType { Pawn, Rook, Knight, Bishop, Queen, King }
public enum PieceColor { White, Black }
public class ChessPiece : MonoBehaviour
{
    public PieceType Type;
    public PieceColor Color;
    [SerializeField] private Image _image;
    
    void Awake()
    {
        enabled = true;
        // if (_image == null) 
        //     _image = GetComponent<Image>(); // ищет Image на том же объекте
    }
    public void Init(
        PieceType type,
        PieceColor color,
        ChessPieceSet set)
    {
        Type = type;
        Color = color;
        _image.sprite = GetSprite(type, color, set);
    }

    Sprite GetSprite(PieceType type, PieceColor color, ChessPieceSet set)
    {
        return (type, color) switch
        {
            (PieceType.Pawn, PieceColor.White) => set.whitePawn,
            (PieceType.Rook, PieceColor.White) => set.whiteRook,
            (PieceType.Knight, PieceColor.White) => set.whiteKnight,
            (PieceType.Bishop, PieceColor.White) => set.whiteBishop,
            (PieceType.Queen, PieceColor.White) => set.whiteQueen,
            (PieceType.King, PieceColor.White) => set.whiteKing,

            (PieceType.Pawn, PieceColor.Black) => set.blackPawn,
            (PieceType.Rook, PieceColor.Black) => set.blackRook,
            (PieceType.Knight, PieceColor.Black) => set.blackKnight,
            (PieceType.Bishop, PieceColor.Black) => set.blackBishop,
            (PieceType.Queen, PieceColor.Black) => set.blackQueen,
            (PieceType.King, PieceColor.Black) => set.blackKing,
            _ => null
        };
    }
}
