# OrderPricing SpecFlow 測試報告

## ExtentReports 整合

此專案已整合 ExtentReports，可自動產生類似 Cucumber Report 的 HTML 測試報告。

### 功能特點

- 🎯 **Feature 總覽**：按功能分組顯示測試結果
- 🏷️ **Tags 分類**：支援 `@order_pricing`、`@bulk_discount` 等標籤分類
- 📋 **Steps 詳細**：顯示每個測試步驟的執行狀態
- ❌ **Failures 分析**：詳細錯誤信息和堆疊追蹤
- 📊 **統計摘要**：測試執行時間和通過率統計
- 🌙 **深色主題**：現代化的報告介面設計

### 報告位置

測試執行後，報告會自動生成在以下位置：

```
tests/OrderPricing.Specs/
├── TestResults/
│   ├── Latest_ExtentReport.html     # 最新報告（方便訪問）
│   └── .gitkeep
└── bin/Debug/net9.0/TestResults/
    └── ExtentReport_YYYYMMDD_HHMMSS.html  # 帶時間戳的報告
```

### 執行測試並生成報告

```bash
# 執行所有測試
dotnet test

# 報告會自動在瀏覽器中開啟（開發環境）
# 或手動開啟：open TestResults/Latest_ExtentReport.html
```

### 報告內容

報告包含以下頁籤：

1. **Tests**: 所有測試的總覽列表
2. **Categories**: 按 Tags 分類的測試
3. **Dashboard**: 測試統計和圖表
4. **Logs**: 詳細的執行日誌

### 系統需求

- .NET 9
- ExtentReports 5.0.4+
- SpecFlow 3.9.74+
- xUnit 2.9.2+

### 自定義配置

報告設定可在 `Support/ExtentTestReporter.cs` 中調整：

- 主題顏色 (Dark/Light)
- 報告標題和描述
- 系統資訊顯示
- 輸出路徑設定