## 🗺️ План развития
Подробный ход разработки и чек-лист задач можно посмотреть в файле: [ROADMAP.md](./ROADMAP.md)

# 💰 Investment Portfolio Aggregator

Бэкенд-сервис для агрегации и анализа инвестиционного портфеля. Позволяет отслеживать состояние активов в реальном времени, объединяя данные с банковских счетов (T-Bank) и криптовалютных бирж (Bybit) в едином интерфейсе.

![Build Status](https://img.shields.io/badge/build-passing-brightgreen) ![.NET](https://img.shields.io/badge/.NET-8.0-purple) ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)

## 🎯 Цель проекта
Решение проблемы разрозненности финансовых данных. Сервис собирает информацию о вложениях из разных источников, конвертирует их в единую валюту и рассчитывает ключевые метрики:
* **Total Invested:** Сумма фактически вложенных средств (Fiat).
* **Current Value:** Текущая рыночная оценка портфеля.
* **PnL (Profit and Loss):** Расчет прибыльности в абсолютных и процентных величинах.

## 🛠 Технологический стек
Проект построен на базе **Clean Architecture**, обеспечивая слабую связность компонентов и высокую тестируемость.

* **Platform:** .NET 8 (ASP.NET Core Web API)
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core (Code First)
* **Background Jobs:** Hangfire / Quartz.NET (обновление котировок по расписанию)
* **External APIs:** Tinkoff Invest API, Bybit API v5
* **Mapping:** AutoMapper / Mapster
* **Documentation:** Swagger / OpenAPI
* **Testing:** xUnit

## 🏗 Архитектура
Решение разделено на слои согласно принципам Чистой Архитектуры:
1.  **Domain:** Основные сущности (`Account`, `Transaction`, `PortfolioSnapshot`) и бизнес-правила. Не имеет внешних зависимостей.
2.  **Application:** Бизнес-логика, UseCases, интерфейсы сервисов.
3.  **Infrastructure:** Реализация работы с БД, внешними API бирж и файловой системой.
4.  **Api:** REST API контроллеры и конфигурация DI-контейнера.

## 🚀 Функциональность
- [x] Учет "ручных" счетов (накопления, наличные).
- [ ] **Интеграция с Т-Банк:** Автоматическая синхронизация фондового портфеля.
- [ ] **Интеграция с Bybit:** Синхронизация крипто-активов с конвертацией в Fiat.
- [ ] **История:** Хранение истории пополнений и изменений стоимости портфеля (снэпшоты).
- [ ] **Аналитика:** Расчет общей доходности (ROI) и распределения активов.

## ⚙️ Установка и запуск

### Предварительные требования
* .NET 8 SDK
* Docker (для запуска БД) или локальный PostgreSQL Server

### Запуск локально
1.  Клонируйте репозиторий:
    ```bash
    git clone [https://github.com/your-username/InvestmentTracker.git](https://github.com/your-username/InvestmentTracker.git)
    ```
2.  Настройте подключение к БД в `appsettings.Development.json` (создайте файл, если нет):
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=InvestmentTrackerDb;Username=postgres;Password=YOUR_PASSWORD"
    }
    ```
3.  Примените миграции:
    ```bash
    dotnet ef database update --project src/InvestmentTracker.Infrastructure --startup-project src/InvestmentTracker.Api
    ```
4.  Запустите API:
    ```bash
    dotnet run --project src/InvestmentTracker.Api
    ```

## 🔐 Безопасность
API-ключи от бирж хранятся в зашифрованном виде (или через UserSecrets в dev-среде). Конфигурационные файлы с секретами исключены из Git.

---
*Проект находится в активной разработке.*
