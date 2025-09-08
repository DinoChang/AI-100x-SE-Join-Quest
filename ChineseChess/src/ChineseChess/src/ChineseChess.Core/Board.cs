namespace ChineseChess.Core
{
    public class Board
    {
        private readonly Dictionary<Position, Piece> _pieces = new();

        public void PlacePiece(Piece piece, Position position)
        {
            _pieces[position] = piece;
        }

        public Piece? GetPiece(Position position)
        {
            _pieces.TryGetValue(position, out var piece);
            return piece;
        }

        public MoveResult MovePiece(Position from, Position to)
        {
            var piece = GetPiece(from);
            if (piece == null)
            {
                return MoveResult.Invalid("No piece found at the source position");
            }

            // 檢查移動是否合法
            if (!piece.IsValidMove(from, to, this))
            {
                return MoveResult.Invalid("Invalid move for this piece");
            }

            // 執行移動
            _pieces.Remove(from);
            _pieces[to] = piece;

            return MoveResult.Valid();
        }
    }
}