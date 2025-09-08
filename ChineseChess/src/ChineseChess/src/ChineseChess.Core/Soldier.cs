namespace ChineseChess.Core
{
    public class Soldier : Piece
    {
        public Soldier(PieceColor color) : base(color)
        {
        }

        public override string Name => "Soldier";

        public override bool IsValidMove(Position from, Position to, Board board)
        {
            // Soldier 移動規則：
            // 1. 過河前只能向前移動一格
            // 2. 過河後可以向前或橫向移動一格
            // 3. 永遠不能向後移動
            
            int rowDiff = to.Row - from.Row;
            int colDiff = to.Col - from.Col;
            
            // 檢查是否只移動一格
            if (Math.Abs(rowDiff) + Math.Abs(colDiff) != 1)
                return false;
            
            if (Color == PieceColor.Red)
            {
                // 紅方兵：向前是增加行數
                
                // 不能向後
                if (rowDiff < 0)
                    return false;
                    
                // 檢查是否已過河（第 6 行開始為過河）
                bool hasCrossedRiver = from.Row >= 6;
                
                if (!hasCrossedRiver)
                {
                    // 過河前只能向前移動
                    return rowDiff == 1 && colDiff == 0;
                }
                else
                {
                    // 過河後可以向前或橫向移動
                    return (rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && Math.Abs(colDiff) == 1);
                }
            }
            else
            {
                // 黑方卒：向前是減少行數
                
                // 不能向後
                if (rowDiff > 0)
                    return false;
                    
                // 檢查是否已過河（第 5 行開始為過河）
                bool hasCrossedRiver = from.Row <= 5;
                
                if (!hasCrossedRiver)
                {
                    // 過河前只能向前移動
                    return rowDiff == -1 && colDiff == 0;
                }
                else
                {
                    // 過河後可以向前或橫向移動
                    return (rowDiff == -1 && colDiff == 0) || (rowDiff == 0 && Math.Abs(colDiff) == 1);
                }
            }
        }
    }
}