namespace ChineseChess.Core
{
    public class Rook : Piece
    {
        public Rook(PieceColor color) : base(color)
        {
        }

        public override string Name => "Rook";

        public override bool IsValidMove(Position from, Position to, Board board)
        {
            // Rook 只能橫/直移動，且路徑上不能有棋子阻擋
            
            // 檢查是否為橫/直移動
            bool isHorizontal = (from.Row == to.Row && from.Col != to.Col);
            bool isVertical = (from.Col == to.Col && from.Row != to.Row);
            
            if (!isHorizontal && !isVertical)
                return false;

            // 檢查路徑是否清空
            if (isHorizontal)
            {
                // 水平移動，檢查列方向
                int minCol = Math.Min(from.Col, to.Col) + 1;
                int maxCol = Math.Max(from.Col, to.Col) - 1;
                
                for (int col = minCol; col <= maxCol; col++)
                {
                    if (board.GetPiece(new Position(from.Row, col)) != null)
                        return false; // 有棋子阻擋
                }
            }
            else // isVertical
            {
                // 垂直移動，檢查行方向
                int minRow = Math.Min(from.Row, to.Row) + 1;
                int maxRow = Math.Max(from.Row, to.Row) - 1;
                
                for (int row = minRow; row <= maxRow; row++)
                {
                    if (board.GetPiece(new Position(row, from.Col)) != null)
                        return false; // 有棋子阻擋
                }
            }

            return true;
        }
    }
}