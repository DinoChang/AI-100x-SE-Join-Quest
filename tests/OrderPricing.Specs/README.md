# OrderPricing SpecFlow 測試報告

## 使用 SpecFlow LivingDoc（官方推薦）

本專案改用 SpecFlow 官方推薦的 LivingDoc 來產生互動式測試報告。建議流程：

### 功能特點


### 報告位置

產生的 HTML 報告可以放在 `docs/` 或 `tests/*/TestResults/` 中，範例：

```
tests/OrderPricing.Specs/
├── TestResults/                # SpecFlow 產生的結果檔
└── Latest_LivingDoc.html       # 透過 LivingDoc 產生的互動式報告
```

### 執行測試並生成報告

```bash
# 執行所有測試（會在 TestResults 目錄產生測試結果）
dotnet test

# 安裝 LivingDoc CLI（若尚未安裝，僅需執行一次）
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI --version 3.9.57

# 使用 LivingDoc 生成報告（在專案根或測試專案目錄執行）
livingdoc test-assembly tests/OrderPricing.Specs/bin/Debug/net9.0/OrderPricing.Specs.dll --output docs/OrderPricing_LivingDoc.html
```

### 系統需求


### 備註
