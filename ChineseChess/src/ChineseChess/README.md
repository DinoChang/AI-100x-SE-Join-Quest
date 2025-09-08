# 中國象棋規則驗證系統 (ChineseChess)

使用行為驅動開發 (BDD) 實作的中國象棋規則引擎，展現完整的測試驅動開發流程。

## 🎯 專案特色

- ✅ **完整 BDD 開發流程** - Red-Green-Refactor 循環
- 🧪 **22 個驗收測試** - 100% 通過率
- 🏗️ **物件導向架構** - 清晰的棋子繼承體系
- 📋 **SpecFlow + xUnit** - 現代化測試框架

## 🚀 快速開始

### 環境需求
- .NET 9.0
- Visual Studio 2022 或 VS Code

### 執行測試
```bash
# 編譯專案
dotnet build

# 執行所有測試
dotnet test

# 查看測試覆蓋率
dotnet test --collect:"XPlat Code Coverage"
```

## 🎲 實作的棋子規則

### 1. General (將/帥) - 3 scenarios
- ✅ 宮殿內移動合法
- ✅ 移出宮殿非法
- ✅ 將帥照面規則

### 2. Guard (士/仕) - 2 scenarios  
- ✅ 宮殿內對角移動合法
- ✅ 直線移動非法

### 3. Rook (車) - 2 scenarios
- ✅ 直線路徑清空移動合法
- ✅ 跳過棋子移動非法

### 4. Horse (馬) - 2 scenarios
- ✅ L 字形移動合法
- ✅ 蹩馬腳規則

### 5. Cannon (炮) - 4 scenarios
- ✅ 空路移動如車
- ✅ 跳吃需恰好一個砲架
- ✅ 零砲架攻擊非法
- ✅ 多砲架攻擊非法

### 6. Elephant (相/象) - 3 scenarios
- ✅ 2 格對角移動合法
- ✅ 過河移動非法
- ✅ 塞象眼阻擋

### 7. Soldier (兵/卒) - 4 scenarios
- ✅ 過河前只能向前
- ✅ 過河前橫移非法
- ✅ 過河後可橫向移動
- ✅ 向後移動永遠非法

### 8. Winning (輸贏) - 2 scenarios
- ✅ 捕獲將軍獲勝
- ✅ 捕獲其他棋子遊戲繼續

## 🏗️ 架構設計

### 核心類別
- `Board` - 棋盤管理
- `Position` - 座標系統 (row, col)
- `Piece` - 棋子基底類別
- `MoveResult` - 移動結果封裝

### 棋子實作
```
ChineseChess.Core/
├── General.cs    # 將/帥
├── Guard.cs      # 士/仕
├── Rook.cs       # 車
├── Horse.cs      # 馬
├── Cannon.cs     # 炮
├── Elephant.cs   # 相/象
└── Soldier.cs    # 兵/卒
```

### 測試架構
```
ChineseChess.Specs/
├── Features/
│   └── chinese-chess.feature
└── StepDefinitions/
    └── ChineseChessSteps.cs
```

## 🔄 BDD 開發流程展現

1. **Walking Skeleton** - 建立基本測試框架
2. **Red 階段** - 撰寫失敗測試
3. **Green 階段** - 實作最小程式碼通過測試
4. **Refactor 階段** - 重構優化程式碼
5. **重複循環** - 逐步完善每個 scenario

## 📊 測試結果

```
Passed!  - Failed: 0, Passed: 22, Skipped: 0, Total: 22
```

## 🎓 學習重點

這個專案完美展現了：
- **需求即測試** - Feature 檔案描述業務規則
- **測試驅動設計** - 測試指引程式碼結構
- **增量開發** - 一次一個 scenario 實作
- **重構安全** - 測試保護下的程式碼改進
- **業務語言** - Given-When-Then 語法

## 🛠️ 技術棧

- **語言**: C# 9.0
- **框架**: .NET 9.0
- **測試**: SpecFlow + xUnit
- **報告**: ExtentReports
- **架構**: 物件導向 + 繼承

---

*這是一個展現 BDD 最佳實踐的完整範例專案，適合學習測試驅動開發和象棋規則實作。*