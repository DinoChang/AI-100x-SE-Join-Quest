namespace ChineseChess.Core
{
    public abstract class Piece
    {
        public PieceColor Color { get; }

        protected Piece(PieceColor color)
        {
            Color = color;
        }

        public abstract bool IsValidMove(Position from, Position to, Board board);
        public abstract string Name { get; }
    }
}