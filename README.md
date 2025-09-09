# AI 軟工百倍研究組織

《 AI 軟工百倍研究組織》是一場由《水球軟體學院》發起的技術研究社群，目標是集結全台具備軟體開發能力的工程師，共同推進 AI × BDD 開發流程的研究與實踐。

「如果大家都關注 AI x BDD 這件事，台灣軟工進度就有機會超前國外；
當國外 AI 軟工都只會寫 rules 時，我們就已經全部都在寫 spec，產值絕對爆增。」

## 本組織將專注於以下目標

1. 本組織相信 AI x BDD 的方法，一定能讓 AI 在背景就產出 80%~90% 可靠且正確的程式，而這一定是未來 Vibe Coding 的趨勢，你一定是想要追求最前沿的軟工技術才加入本組織。

2. 組織規劃好了初步研究藍圖，分為底下三大路線，每一大路線賞金十萬：​你的參與，不僅代表你願意走在 AI 軟體開發方法論的最前線，更代表你願意投身於一場嚴謹、務實、強調產出價值與技術驗證的研究歷程。

   a. 開發流程全自動化（後端）— Feature file (BDD) 到 API Spec/ERD 到程式
   
   b. 開發流程全自動化（前端）— 線框 到 User-flow (BDD) 到程式
   
   c. 回饋流程智能化 (全端) — 前後端整合自動化建立新的驗收測試

這三者只要都研究完成，那 Vibe Coding 才算是成熟，軟體工程師能與與 AI 「平行」合作帶來百倍產出，故稱「AI 百倍軟工研究組織」。

## 歡迎所有人參與

你的參與，不僅代表你願意走在 AI 軟體開發方法論的最前線，更代表你願意投身於一場嚴謹、務實、強調產出價值與技術驗證的研究歷程（所有的研究紀錄都會使用 Github Repository 保存脈絡）。

報名方法：
1. 加入水球軟體學院 Discord：https://discord.gg/uWGTF7RSnW
2. 照著此 Discord 社群內 #加入研究計劃 置頂訊息的指示進行即可成功報名

若你已準備好成為推動 AI × BDD 開發方法的革新者，誠摯邀請你完成報名，與來自全台的技術夥伴攜手共創。

---

# 入會任務：訂單優惠模組

## 🎯 專案簡介

使用 **行為驅動開發 (BDD)** 方法實作完整的電商訂單優惠模組，包含門檻折扣和買一送一等促銷功能。

## 🏗️ 系統架構

```
OrderPricing/
├── src/OrderPricing.Core/           # 核心業務邏輯
│   ├── Entities/                    # 實體層
│   │   ├── Order.cs                 # 訂單實體
│   │   ├── OrderItem.cs             # 訂單項目實體
│   │   └── Product.cs               # 商品實體
│   └── Services/                    # 服務層
│       ├── OrderService.cs          # 訂單服務
│       ├── IDiscountRule.cs         # 折扣規則介面
│       ├── ThresholdDiscountRule.cs # 門檻折扣規則
│       ├── BuyOneGetOneRule.cs      # 買一送一規則
│       └── BulkDiscountRule.cs      # 量販折扣規則
└── tests/OrderPricing.Specs/        # BDD 測試套件
    ├── Features/
    │   ├── order.feature            # BDD 驗收條件 (基本功能)
    │   └── bulk_discount.feature    # BDD 驗收條件 (量販折扣)
    └── StepDefinitions/
        ├── OrderSteps.cs            # 基本測試步驟定義
        └── BulkDiscountSteps.cs     # 量販折扣測試步驟定義
```

## ✨ 核心功能

### 1. 基礎訂單處理
- 單一商品無優惠計算
- 原始金額、折扣金額、總金額計算

### 2. 門檻折扣優惠
- 滿 1000 元折 100 元
- 可配置門檻金額和折扣金額

### 3. 買一送一優惠
- 化妝品類別專屬優惠
- 買 n 個送 max(1, floor(n/2)) 個
- 支援多種商品和同商品組合

### 4. 量販折扣優惠 **[🆕 新增]**
- 同一種商品每買 10 件享有 20% 折扣
- 支援多組折扣計算（如 27 件 = 2 組折扣 + 7 件原價）
- 不同商品各自計算，無法合併折扣組數

### 5. 多重優惠疊加
- 門檻折扣 + 買一送一同時適用
- 優惠計算順序：買一送一影響數量，門檻折扣影響價格

## 🧪 BDD 驗收場景

### 基本功能測試 (order.feature)
| 場景 | 描述 | 狀態 |
|------|------|------|
| Scenario 1 | 單一商品無優惠 | ✅ 通過 |
| Scenario 2 | 門檻折扣適用 | ✅ 通過 |
| Scenario 3 | 買一送一多商品 | ✅ 通過 |
| Scenario 4 | 買一送一同商品 | ✅ 通過 |
| Scenario 5 | 混合類別商品 | ✅ 通過 |
| Scenario 6 | 多重優惠疊加 | ✅ 通過 |

### 量販折扣測試 (bulk_discount.feature) **[🆕 新增]**
| 場景 | 描述 | 狀態 |
|------|------|------|
| Scenario 1 | 購買 12 件同種商品 (部分量販折扣) | ✅ 通過 |
| Scenario 2 | 購買 27 件同種商品 (多組量販折扣) | ✅ 通過 |
| Scenario 3 | 購買 10 種不同商品 (無量販折扣) | ✅ 通過 |
| Scenario 4 | 購買恰好 10 件同種商品 (完整量販折扣) | ✅ 通過 |
| Scenario 5 | 混合商品購買 (部分商品量販折扣) | ✅ 通過 |

**測試覆蓋率**: 11/11 scenarios ✅ (100% 通過)

## 🔧 技術特點

### 設計模式
- **Strategy Pattern**: 可擴展的折扣規則系統
- **開放封閉原則 (OCP)**: 新增折扣規則無需修改既有程式碼

### 開發方法
- **行為驅動開發 (BDD)**: 從驗收條件到程式實作
- **測試驅動開發 (TDD)**: Red-Green-Refactor 循環
- **Clean Code**: 職責分離、模組化設計

### 技術棧
- **.NET 9**: 現代化 C# 開發平台
- **SpecFlow**: BDD 測試框架
- **xUnit**: 單元測試框架

## 🚀 快速開始

### 前置需求
- .NET 9 SDK
- Visual Studio Code 或 Visual Studio

### 執行步驟

1. **複製專案**
   ```bash
   git clone https://github.com/AI-100x-SE/AI-100x-SE-Join-Quest.git
   cd AI-100x-SE-Join-Quest
   ```

2. **建置專案**
   ```bash
   dotnet build
   ```

3. **執行測試**
   ```bash
   dotnet test
   ```

4. **查看測試報告**
   ```
   Passed: 11, Failed: 0, Skipped: 0
   ✅ 所有 BDD 場景測試通過 (包含新增的量販折扣功能)
   ```

5. **產生 LivingDoc 測試報告 (官方推薦)**
   ```bash
   # 執行測試並產生 SpecFlow 結果
   dotnet test

   # 使用 SpecFlow LivingDoc 工具將測試結果轉成互動式 HTML
   # 需要先安裝 dotnet tool (僅需安裝一次)：
   # dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI --version 3.9.74

   # 產生 LivingDoc 報告 (範例：OrderPricing)
   livingdoc test-results --testResult tests/OrderPricing.Specs/TestResults --output docs/OrderPricing_LivingDoc.html
   ```

   報告包含：
   - Features 與 Scenarios 的互動式檢視
   - Tags 標籤分類
   - Steps 詳細步驟（來自 SpecFlow 結果）
   - 可在 CI 中產生並上傳 HTML

## 📋 開發流程

### BDD 循環實作
1. **Red Phase**: 撰寫失敗測試，確認測試框架運作
2. **Green Phase**: 實作最小功能讓測試通過
3. **Refactor Phase**: 重構程式碼提升品質

### 品質保證
- 程式碼格式化: `dotnet format`
- 靜態分析: 0 critical issues
- 測試覆蓋: 100% scenario 覆蓋

## 🎓 學習成果

### BDD 實踐
- ✅ Walking Skeleton 建置
- ✅ 嚴格遵循一次一個 scenario 開發
- ✅ 從驗收條件到可執行程式碼

### 軟體設計
- ✅ SOLID 原則應用
- ✅ Strategy Pattern 實作
- ✅ 開放封閉原則重構

### .NET 技術
- ✅ .NET 9 現代化語法 (Primary Constructor)
- ✅ SpecFlow BDD 整合
- ✅ 專案架構組織
- ✅ ScenarioContext 資源共享管理
- ✅ SpecFlow LivingDoc 測試報告整合

### 測試報告
- ✅ SpecFlow LivingDoc 互動式 HTML 報告
- ✅ Cucumber 風格的測試結果檢視
- ✅ Features、Tags、Steps 詳細分類
- ✅ 與平行測試相容（結果由 plugin 匯總）

---

# 中國象棋遊戲模組 **[🆕 新增]**

## 🎯 專案簡介

基於 **行為驅動開發 (BDD)** 實作的中國象棋遊戲引擎，包含完整的棋盤邏輯、棋子移動規則和遊戲狀態管理。

## 🏗️ 系統架構

```
ChineseChess/
└── src/ChineseChess/
    ├── src/ChineseChess.Core/          # 核心遊戲邏輯
    │   ├── Board.cs                    # 棋盤管理
    │   ├── Piece.cs                    # 抽象棋子基類
    │   ├── Position.cs                 # 位置座標
    │   ├── PieceColor.cs               # 棋子顏色枚舉
    │   ├── MoveResult.cs               # 移動結果
    │   ├── General.cs                  # 將/帥
    │   ├── Guard.cs                    # 士/仕
    │   ├── Elephant.cs                 # 象/相
    │   ├── Horse.cs                    # 馬
    │   ├── Rook.cs                     # 車
    │   ├── Cannon.cs                   # 砲
    │   └── Soldier.cs                  # 兵/卒
    └── tests/ChineseChess.Specs/       # BDD 測試套件
        ├── Features/
        │   └── chinese-chess.feature   # BDD 驗收條件
        ├── StepDefinitions/
        │   └── ChineseChessSteps.cs    # 測試步驟定義
      ├── Support/
      │   └── (測試報告由 SpecFlow LivingDoc 產生，原 ExtentReports 支援已移除)
      └── Hooks/
         └── (原 ExtentReport hooks 已移除，請改用 SpecFlow hooks)
```

## 🧪 BDD 驗收場景

**測試覆蓋率**: 22/22 scenarios ✅ (100% 通過)

### 中國象棋測試 (chinese-chess.feature)
| 場景類型 | 描述 | 狀態 |
|---------|------|------|
| 基本棋盤 | 棋盤初始化和棋子擺放 | ✅ 通過 |
| 將/帥移動 | 將帥的移動規則驗證 | ✅ 通過 |
| 士/仕移動 | 士仕的對角線移動 | ✅ 通過 |
| 象/相移動 | 象相的田字移動 | ✅ 通過 |
| 馬移動 | 馬的日字移動和蹩腿 | ✅ 通過 |
| 車移動 | 車的直線移動 | ✅ 通過 |
| 砲移動 | 砲的隔子打法 | ✅ 通過 |
| 兵/卒移動 | 兵卒的前進和橫移 | ✅ 通過 |

## ✨ 核心功能

### 1. 棋盤系統
- 10×9 標準中國象棋棋盤
- 棋子擺放和位置管理
- 棋盤狀態查詢

### 2. 棋子移動邏輯
- **將/帥**: 僅能在九宮格內移動，一次一格
- **士/仕**: 沿九宮格對角線移動，一次一格
- **象/相**: 沿對角線兩格移動，不能過河，不能被蹩象眼
- **馬**: 日字型移動，會被蹩馬腿
- **車**: 水平和垂直直線移動，可跨越多格
- **砲**: 移動如車，但攻擊需隔一子
- **兵/卒**: 未過河只能向前，過河後可橫移

### 3. 遊戲規則
- 邊界檢查和位置驗證
- 棋子移動合法性檢查
- 不能過河限制 (象、兵)

## 🔧 技術特點

-
### 測試報告（使用 SpecFlow LivingDoc）

本專案已將測試報告流程統一採用 SpecFlow 官方推薦的 LivingDoc：

- 在執行 `dotnet test` 時，已透過 `SpecFlow.Plus.LivingDocPlugin` 產生 `TestExecution.json`。
- 使用官方 CLI 將 `TestExecution.json` 或 test-results 轉為互動式 HTML。

建議安裝版本：`SpecFlow.Plus.LivingDoc.CLI` 3.9.57（與專案 plugin 相容）。

範例生成流程：

```bash
# 執行測試，LivingDoc plugin 會輸出 TestExecution.json 至測試專案的 bin 目錄
dotnet test ./tests/OrderPricing.Specs/OrderPricing.Specs.csproj

# 使用 CLI 生成 HTML（示範 ChineseChess）
# 如果尚未安裝 CLI：
# dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI --version 3.9.57
livingdoc test-assembly ChineseChess/src/ChineseChess/tests/ChineseChess.Specs/bin/Debug/net9.0/ChineseChess.Specs.dll --output docs/ChineseChess_LivingDoc.html
```
- **物件導向設計**: 抽象棋子類別與具體實作
- **策略模式**: 各種棋子的移動策略獨立實作
- **封裝**: 棋盤和棋子的內部狀態保護

## 🚀 快速開始

### 執行 ChineseChess 測試

1. **進入 ChineseChess 目錄**
   ```bash
   cd ChineseChess/src/ChineseChess
   ```

2. **建置專案**
   ```bash
   dotnet build
   ```

3. **執行測試**
   ```bash
   dotnet test
   ```

4. **查看測試報告**
   ```
   Passed: 22, Failed: 0, Skipped: 0
   ✅ 所有 BDD 場景測試通過
   ```

5. **產生 ChineseChess LivingDoc 測試報告**
   ```bash
   # 執行測試
   dotnet test

   # 生成 LivingDoc 報告（先安裝 CLI）：
   # dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI --version 3.9.57
   livingdoc test-results --testResult tests/ChineseChess.Specs/bin/Debug/net9.0/TestExecution.json --output docs/ChineseChess_LivingDoc.html
   ```

## 📁 專案結構重整 **[🆕 完成]**

### 重整成果
- ✅ 建立清晰的 `docs/` 目錄結構
- ✅ 架構文件整理至 `docs/architecture/`
- ✅ 提示詞文件移至 `docs/prompts/`
- ✅ 範例 Feature 檔案移至 `docs/features/`
- ✅ 任務文件整理至 `docs/tasks/`
- ✅ 指南文件移至 `docs/guides/`
- ✅ 清理重複和空的檔案/目錄
- ✅ 驗證所有專案編譯和測試正常

### 新的專案結構
```
AI-100x-SE-Join-Quest/
├── docs/                           # 📚 所有文檔集中
│   ├── architecture/              # 🏗️ 架構相關 (ERD.png, OOD.png, ooad.asta)
│   ├── prompts/                   # 🤖 AI 提示詞 (BDD.prompt, OCP-Refactor.prompt)
│   ├── features/                  # 📝 範例 feature 檔案
│   ├── guides/                    # 📖 指南文件 (join-quest/, quick-start/, rules/)
│   ├── tasks/                     # 📋 任務文件 (ren-wu-*.md)
│   ├── bounty-policy.md
│   ├── member-obligations.md
│   └── SUMMARY.md
├── src/OrderPricing.Core/          # 💼 OrderPricing 核心業務邏輯
├── tests/OrderPricing.Specs/       # 🧪 OrderPricing BDD 測試
├── ChineseChess/                   # ♟️ ChineseChess 獨立專案
├── OrderPricing.sln               # 📄 主要解決方案檔
└── README.md
```

---

> 此專案展示了從需求分析、BDD 實作、程式重構到專案結構優化的完整軟體開發流程，涵蓋 OrderPricing 電商模組和 ChineseChess 遊戲引擎，符合 AI 軟工百倍研究組織的入會任務要求。

**最後更新**: 2025-09-08 
- ✅ 已將 ChineseChess 測試報告遷移至 SpecFlow LivingDoc（取代 ExtentReports）
- ✅ 完成專案檔案結構重整優化
- ✅ 所有專案編譯測試通過 (OrderPricing: 11/11, ChineseChess: 22/22)