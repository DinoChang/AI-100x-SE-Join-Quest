namespace ChineseChess.Core
{
    public class Elephant(PieceColor color) : Piece(color)
    {
        public override string Name => "Elephant";

        public override bool IsValidMove(Position from, Position to, Board board)
        {
            // Elephant 只能對角移動 2 格，且不能過河，不能被「塞象眼」
            
            // 檢查是否為 2 格對角移動
            int rowDiff = Math.Abs(to.Row - from.Row);
            int colDiff = Math.Abs(to.Col - from.Col);
            
            if (rowDiff != 2 || colDiff != 2)
                return false;

            // 檢查是否過河
            if (Color == PieceColor.Red)
            {
                // 紅方象不能過河（不能到第 6-10 行）
                if (to.Row > 5)
                    return false;
            }
            else
            {
                // 黑方象不能過河（不能到第 1-5 行）
                if (to.Row < 6)
                    return false;
            }

            // 檢查「塞象眼」- 中間點是否被阻擋
            Position midpoint = GetMidpoint(from, to);
            if (board.GetPiece(midpoint) != null)
                return false; // 象眼被塞住

            return true;
        }

        private Position GetMidpoint(Position from, Position to)
        {
            // 計算對角移動的中間點
            int midRow = (from.Row + to.Row) / 2;
            int midCol = (from.Col + to.Col) / 2;
            return new Position(midRow, midCol);
        }
    }
}