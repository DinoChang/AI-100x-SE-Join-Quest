namespace ChineseChess.Core
{
    public class Guard : Piece
    {
        public Guard(PieceColor color) : base(color)
        {
        }

        public override string Name => "Guard";

        public override bool IsValidMove(Position from, Position to, Board board)
        {
            // Guard 只能在宮殿內對角移動一格
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

            // 檢查是否只對角移動一格
            int rowDiff = Math.Abs(to.Row - from.Row);
            int colDiff = Math.Abs(to.Col - from.Col);
            
            return rowDiff == 1 && colDiff == 1;
        }
    }
}