namespace ChineseChess.Core
{
    public class Horse : Piece
    {
        public Horse(PieceColor color) : base(color)
        {
        }

        public override string Name => "Horse";

        public override bool IsValidMove(Position from, Position to, Board board)
        {
            // Horse 移動呈 "日" 字形（L 字形），且不能被「蹩馬腳」
            int rowDiff = Math.Abs(to.Row - from.Row);
            int colDiff = Math.Abs(to.Col - from.Col);
            
            // 檢查是否為有效的 L 字形移動
            bool isValidLShape = (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
            
            if (!isValidLShape)
                return false;

            // 檢查是否被「蹩馬腳」
            Position legPosition = GetLegPosition(from, to);
            if (board.GetPiece(legPosition) != null)
                return false; // 馬腳被擋住

            return true;
        }

        private Position GetLegPosition(Position from, Position to)
        {
            // 計算「馬腳」位置（阻擋點）
            int rowDiff = to.Row - from.Row;
            int colDiff = to.Col - from.Col;
            
            if (Math.Abs(rowDiff) == 2)
            {
                // 縱向移動 2 格，橫向移動 1 格
                // 馬腳在縱向移動的第一格
                int legRow = from.Row + (rowDiff > 0 ? 1 : -1);
                return new Position(legRow, from.Col);
            }
            else
            {
                // 橫向移動 2 格，縱向移動 1 格
                // 馬腳在橫向移動的第一格
                int legCol = from.Col + (colDiff > 0 ? 1 : -1);
                return new Position(from.Row, legCol);
            }
        }
    }
}