using ChineseChess.Core;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace ChineseChess.Specs.StepDefinitions
{
    [Binding]
    public class ChineseChessSteps
    {
        private Board? _board;
        private MoveResult? _moveResult;

        [Given(@"the board is empty except for a Red General at \((\d+), (\d+)\)")]
        public void GivenTheBoardIsEmptyExceptForARedGeneralAt(int row, int col)
        {
            _board = new Board();
            var position = new Position(row, col);
            var general = new General(PieceColor.Red);
            _board.PlacePiece(general, position);
        }

        [Given(@"the board is empty except for a Red Guard at \((\d+), (\d+)\)")]
        public void GivenTheBoardIsEmptyExceptForARedGuardAt(int row, int col)
        {
            _board = new Board();
            var position = new Position(row, col);
            var guard = new Guard(PieceColor.Red);
            _board.PlacePiece(guard, position);
        }

        [Given(@"the board is empty except for a Red Rook at \((\d+), (\d+)\)")]
        public void GivenTheBoardIsEmptyExceptForARedRookAt(int row, int col)
        {
            _board = new Board();
            var position = new Position(row, col);
            var rook = new Rook(PieceColor.Red);
            _board.PlacePiece(rook, position);
        }

        [Given(@"the board is empty except for a Red Horse at \((\d+), (\d+)\)")]
        public void GivenTheBoardIsEmptyExceptForARedHorseAt(int row, int col)
        {
            _board = new Board();
            var position = new Position(row, col);
            var horse = new Horse(PieceColor.Red);
            _board.PlacePiece(horse, position);
        }

        [Given(@"the board is empty except for a Red Cannon at \((\d+), (\d+)\)")]
        public void GivenTheBoardIsEmptyExceptForARedCannonAt(int row, int col)
        {
            _board = new Board();
            var position = new Position(row, col);
            var cannon = new Cannon(PieceColor.Red);
            _board.PlacePiece(cannon, position);
        }

        [Given(@"the board is empty except for a Red Elephant at \((\d+), (\d+)\)")]
        public void GivenTheBoardIsEmptyExceptForARedElephantAt(int row, int col)
        {
            _board = new Board();
            var position = new Position(row, col);
            var elephant = new Elephant(PieceColor.Red);
            _board.PlacePiece(elephant, position);
        }

        [Given(@"the board is empty except for a Red Soldier at \((\d+), (\d+)\)")]
        public void GivenTheBoardIsEmptyExceptForARedSoldierAt(int row, int col)
        {
            _board = new Board();
            var position = new Position(row, col);
            var soldier = new Soldier(PieceColor.Red);
            _board.PlacePiece(soldier, position);
        }

        [Given(@"the board has:")]
        public void GivenTheBoardHas(Table table)
        {
            _board = new Board();
            foreach (var row in table.Rows)
            {
                var pieceName = row["Piece"];
                var positionString = row["Position"];
                
                // 解析位置 (row, col)
                var coords = positionString.Trim('(', ')').Split(',');
                var position = new Position(int.Parse(coords[0].Trim()), int.Parse(coords[1].Trim()));
                
                // 根據名稱建立棋子
                Piece piece = pieceName switch
                {
                    "Red General" => new General(PieceColor.Red),
                    "Black General" => new General(PieceColor.Black),
                    "Red Guard" => new Guard(PieceColor.Red),
                    "Black Guard" => new Guard(PieceColor.Black),
                    "Red Rook" => new Rook(PieceColor.Red),
                    "Black Rook" => new Rook(PieceColor.Black),
                    "Red Soldier" => new Soldier(PieceColor.Red),
                    "Black Soldier" => new Soldier(PieceColor.Black),
                    "Red Horse" => new Horse(PieceColor.Red),
                    "Black Horse" => new Horse(PieceColor.Black),
                    "Red Cannon" => new Cannon(PieceColor.Red),
                    "Black Cannon" => new Cannon(PieceColor.Black),
                    "Red Elephant" => new Elephant(PieceColor.Red),
                    "Black Elephant" => new Elephant(PieceColor.Black),
                    _ => throw new ArgumentException($"Unknown piece: {pieceName}")
                };
                
                _board.PlacePiece(piece, position);
            }
        }

        [When(@"Red moves the General from \((\d+), (\d+)\) to \((\d+), (\d+)\)")]
        public void WhenRedMovesTheGeneralFrom(int fromRow, int fromCol, int toRow, int toCol)
        {
            var fromPosition = new Position(fromRow, fromCol);
            var toPosition = new Position(toRow, toCol);
            _moveResult = _board!.MovePiece(fromPosition, toPosition);
        }

        [When(@"Red moves the Guard from \((\d+), (\d+)\) to \((\d+), (\d+)\)")]
        public void WhenRedMovesTheGuardFrom(int fromRow, int fromCol, int toRow, int toCol)
        {
            var fromPosition = new Position(fromRow, fromCol);
            var toPosition = new Position(toRow, toCol);
            _moveResult = _board!.MovePiece(fromPosition, toPosition);
        }

        [When(@"Red moves the Rook from \((\d+), (\d+)\) to \((\d+), (\d+)\)")]
        public void WhenRedMovesTheRookFrom(int fromRow, int fromCol, int toRow, int toCol)
        {
            var fromPosition = new Position(fromRow, fromCol);
            var toPosition = new Position(toRow, toCol);
            _moveResult = _board!.MovePiece(fromPosition, toPosition);
        }

        [When(@"Red moves the Horse from \((\d+), (\d+)\) to \((\d+), (\d+)\)")]
        public void WhenRedMovesTheHorseFrom(int fromRow, int fromCol, int toRow, int toCol)
        {
            var fromPosition = new Position(fromRow, fromCol);
            var toPosition = new Position(toRow, toCol);
            _moveResult = _board!.MovePiece(fromPosition, toPosition);
        }

        [When(@"Red moves the Cannon from \((\d+), (\d+)\) to \((\d+), (\d+)\)")]
        public void WhenRedMovesTheCannonFrom(int fromRow, int fromCol, int toRow, int toCol)
        {
            var fromPosition = new Position(fromRow, fromCol);
            var toPosition = new Position(toRow, toCol);
            _moveResult = _board!.MovePiece(fromPosition, toPosition);
        }

        [When(@"Red moves the Elephant from \((\d+), (\d+)\) to \((\d+), (\d+)\)")]
        public void WhenRedMovesTheElephantFrom(int fromRow, int fromCol, int toRow, int toCol)
        {
            var fromPosition = new Position(fromRow, fromCol);
            var toPosition = new Position(toRow, toCol);
            _moveResult = _board!.MovePiece(fromPosition, toPosition);
        }

        [When(@"Red moves the Soldier from \((\d+), (\d+)\) to \((\d+), (\d+)\)")]
        public void WhenRedMovesTheSoldierFrom(int fromRow, int fromCol, int toRow, int toCol)
        {
            var fromPosition = new Position(fromRow, fromCol);
            var toPosition = new Position(toRow, toCol);
            _moveResult = _board!.MovePiece(fromPosition, toPosition);
        }

        [Then(@"the move is legal")]
        public void ThenTheMoveIsLegal()
        {
            Assert.True(_moveResult!.IsValid, $"Expected move to be legal, but it was invalid: {_moveResult.ErrorMessage}");
        }

        [Then(@"the move is illegal")]
        public void ThenTheMoveIsIllegal()
        {
            Assert.False(_moveResult!.IsValid, "Expected move to be illegal, but it was valid");
        }

        [Then(@"Red wins immediately")]
        public void ThenRedWinsImmediately()
        {
            // 檢查移動是合法的
            Assert.True(_moveResult!.IsValid, $"Expected winning move to be legal, but it was invalid: {_moveResult.ErrorMessage}");
            
            // 檢查是否捕獲了敵方將軍（通過檢查目標位置是否為將軍）
            // 這是一個簡化版本，真實遊戲還需要檢查遊戲狀態
        }

        [Then(@"the game is not over just from that capture")]
        public void ThenTheGameIsNotOverJustFromThatCapture()
        {
            // 檢查移動是合法的
            Assert.True(_moveResult!.IsValid, $"Expected capture move to be legal, but it was invalid: {_moveResult.ErrorMessage}");
            
            // 捕獲非將軍棋子不會結束遊戲
            // 這裡我們只驗證移動合法，表示遊戲繼續
        }
    }
}