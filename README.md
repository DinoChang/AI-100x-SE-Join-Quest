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

5. **查看 ExtentReports 測試報告**
   ```bash
   # 測試報告會自動生成在 TestResults 目錄
   open tests/OrderPricing.Specs/TestResults/Latest_ExtentReport.html
   ```
   
   報告包含：
   - Features 功能總覽
   - Tags 標籤分類 (@order_pricing, @bulk_discount)
   - Steps 詳細步驟記錄
   - 測試統計和執行時間

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
- ✅ ExtentReports 測試報告整合

### 測試報告
- ✅ ExtentReports HTML 報告生成
- ✅ Cucumber 風格的測試結果展示
- ✅ Features、Tags、Steps 詳細分類
- ✅ 深色主題和現代化介面
- ✅ 解決平行測試執行的顯示問題
- ✅ 使用 ConcurrentDictionary 確保執行緒安全

---

> 此專案展示了從需求分析、BDD 實作到程式重構的完整軟體開發流程，符合 AI 軟工百倍研究組織的入會任務要求。