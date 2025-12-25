using UnityEngine;

[CreateAssetMenu(fileName = "ChessPieceSet", menuName = "Scriptable Objects/ChessPieceSet")]
public class ChessPieceSet : ScriptableObject
{
    public Sprite whitePawn;
    public Sprite whiteRook;
    public Sprite whiteKnight;
    public Sprite whiteBishop;
    public Sprite whiteQueen;
    public Sprite whiteKing;

    public Sprite blackPawn;
    public Sprite blackRook;
    public Sprite blackKnight;
    public Sprite blackBishop;
    public Sprite blackQueen;
    public Sprite blackKing;
}
