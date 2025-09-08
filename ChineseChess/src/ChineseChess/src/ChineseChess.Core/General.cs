namespace ChineseChess.Core
{
    public class General : Piece
    {
        public General(PieceColor color) : base(color)
        {
        }

        public override string Name => "General";

        public override bool IsValidMove(Position from, Position to, Board board)
        {
            // General 只能在宮殿內移動，每次移動一格（橫、直）
            // 紅方宮殿：Row 1-3, Col 4-6
            // 黑方宮殿：Row 8-10, Col 4-6
            
            if (Color == PieceColor.Red)
            {
                // 檢查是否在紅方宮殿範圍內
                if (to.Row < 1 || to.Row > 3 || to.Col < 4 || to.Col > 6)
                    return false;
            }
            else
            {
                // 檢查是否在黑方宮殿範圍內
                if (to.Row < 8 || to.Row > 10 || to.Col < 4 || to.Col > 6)
                    return false;
            }

            // 檢查是否只移動一格（橫移或直移）
            int rowDiff = Math.Abs(to.Row - from.Row);
            int colDiff = Math.Abs(to.Col - from.Col);
            
            if (!((rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1)))
                return false;

            // 檢查將帥照面規則
            if (WouldGeneralsFaceEachOther(to, board))
                return false;

            return true;
        }

        private bool WouldGeneralsFaceEachOther(Position myNewPosition, Board board)
        {
            // 尋找對方的將/帥
            General? enemyGeneral = null;
            Position? enemyPosition = null;

            for (int row = 1; row <= 10; row++)
            {
                for (int col = 1; col <= 9; col++)
                {
                    var pos = new Position(row, col);
                    var piece = board.GetPiece(pos);
                    
                    if (piece is General general && general.Color != Color)
                    {
                        enemyGeneral = general;
                        enemyPosition = pos;
                        break;
                    }
                }
                if (enemyGeneral != null) break;
            }

            if (enemyGeneral == null || enemyPosition == null)
                return false;

            // 檢查是否在同一列或同一行
            bool sameFile = (myNewPosition.Col == enemyPosition.Col);
            bool sameRank = (myNewPosition.Row == enemyPosition.Row);

            if (!sameFile && !sameRank)
                return false;

            // 檢查中間是否有棋子阻擋
            if (sameFile)
            {
                // 同一列，檢查行之間是否有棋子
                int minRow = Math.Min(myNewPosition.Row, enemyPosition.Row) + 1;
                int maxRow = Math.Max(myNewPosition.Row, enemyPosition.Row) - 1;
                
                for (int row = minRow; row <= maxRow; row++)
                {
                    if (board.GetPiece(new Position(row, myNewPosition.Col)) != null)
                        return false; // 有棋子阻擋，不會照面
                }
            }
            else if (sameRank)
            {
                // 同一行，檢查列之間是否有棋子
                int minCol = Math.Min(myNewPosition.Col, enemyPosition.Col) + 1;
                int maxCol = Math.Max(myNewPosition.Col, enemyPosition.Col) - 1;
                
                for (int col = minCol; col <= maxCol; col++)
                {
                    if (board.GetPiece(new Position(myNewPosition.Row, col)) != null)
                        return false; // 有棋子阻擋，不會照面
                }
            }

            return true; // 會照面
        }
    }
}