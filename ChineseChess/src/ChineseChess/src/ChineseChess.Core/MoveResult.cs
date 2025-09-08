namespace ChineseChess.Core
{
    public class MoveResult
    {
        public bool IsValid { get; }
        public string? ErrorMessage { get; }
        
        private MoveResult(bool isValid, string? errorMessage = null)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
        
        public static MoveResult Valid()
        {
            return new MoveResult(true);
        }
        
        public static MoveResult Invalid(string errorMessage)
        {
            return new MoveResult(false, errorMessage);
        }
    }
}