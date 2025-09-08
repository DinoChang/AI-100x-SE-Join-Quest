namespace ChineseChess.Core
{
    public class Cannon : Piece
    {
        public Cannon(PieceColor color) : base(color)
        {
        }

        public override string Name => "Cannon";

        public override bool IsValidMove(Position from, Position to, Board board)
        {
            // Cannon 橫/直移動，移動時如車，攻擊時需要跳棋（砲架）
            
            // 檢查是否為橫/直移動
            bool isHorizontal = (from.Row == to.Row && from.Col != to.Col);
            bool isVertical = (from.Col == to.Col && from.Row != to.Row);
            
            if (!isHorizontal && !isVertical)
                return false;

            // 檢查目標位置是否有棋子
            var targetPiece = board.GetPiece(to);
            
            if (targetPiece == null)
            {
                // 移動到空位，路徑必須清空（如車）
                return IsPathClear(from, to, board);
            }
            else
            {
                // 攻擊敵方棋子，需要恰好一個砲架
                if (targetPiece.Color == Color)
                    return false; // 不能攻擊己方棋子
                
                return HasExactlyOneScreen(from, to, board);
            }
        }

        private bool IsPathClear(Position from, Position to, Board board)
        {
            if (from.Row == to.Row)
            {
                // 水平移動
                int minCol = Math.Min(from.Col, to.Col) + 1;
                int maxCol = Math.Max(from.Col, to.Col) - 1;
                
                for (int col = minCol; col <= maxCol; col++)
                {
                    if (board.GetPiece(new Position(from.Row, col)) != null)
                        return false;
                }
            }
            else
            {
                // 垂直移動
                int minRow = Math.Min(from.Row, to.Row) + 1;
                int maxRow = Math.Max(from.Row, to.Row) - 1;
                
                for (int row = minRow; row <= maxRow; row++)
                {
                    if (board.GetPiece(new Position(row, from.Col)) != null)
                        return false;
                }
            }
            
            return true;
        }

        private bool HasExactlyOneScreen(Position from, Position to, Board board)
        {
            int screenCount = 0;
            
            if (from.Row == to.Row)
            {
                // 水平攻擊
                int minCol = Math.Min(from.Col, to.Col) + 1;
                int maxCol = Math.Max(from.Col, to.Col) - 1;
                
                for (int col = minCol; col <= maxCol; col++)
                {
                    if (board.GetPiece(new Position(from.Row, col)) != null)
                        screenCount++;
                }
            }
            else
            {
                // 垂直攻擊
                int minRow = Math.Min(from.Row, to.Row) + 1;
                int maxRow = Math.Max(from.Row, to.Row) - 1;
                
                for (int row = minRow; row <= maxRow; row++)
                {
                    if (board.GetPiece(new Position(row, from.Col)) != null)
                        screenCount++;
                }
            }
            
            return screenCount == 1; // 恰好一個砲架
        }
    }
}