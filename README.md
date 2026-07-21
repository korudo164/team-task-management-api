# Team Task Management System

## 技術棧
- Backend: ASP.NET Core Web API (.NET 10)
- Database: PostgreSQL
- ORM: Entity Framework Core (Npgsql)
- API 測試介面: Scalar

## 如何啟動
1. 安裝 .NET 10 SDK、PostgreSQL
2. 建立資料庫 `taskmanagement_dev`
3. 在 appsettings.json 設定連線字串
4. 執行 `dotnet ef database update`
5. 執行 `dotnet run`
6. 打開 http://localhost:5xxx/scalar/v1 測試 API

## 目前進度
- [x] 專案骨架建立
- [x] 資料庫連線設定
- [x] 第一組 CRUD API（TaskItem）