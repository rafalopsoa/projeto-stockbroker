# 📈 StockBroker API (.NET 8)

[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-brightgreen.svg)]()
[![Testing](https://img.shields.io/badge/Testing-TDD%20%7C%20BDD-blue.svg)]()

*(🇺🇸 Read in English below)*

## 🇧🇷 Sobre o Projeto
O **StockBroker** é uma API RESTful desenvolvida em C# (.NET 8) que simula o ecossistema de roteamento de ordens e regras de negócio de uma corretora operando na B3 (Bolsa de Valores do Brasil). 

O sistema foi arquitetado com um forte foco em qualidade de software, isolamento de domínio e prevenção de anomalias transacionais financeiras (como *Double Spending*).

### ⚙️ Principais Funcionalidades e Regras de Negócio (Domínio B3)
* **Motor de Validação:** Validação estrita de lote padrão (múltiplos de 100) vs. mercado fracionário.
* **Gestão de Saldo (Buying Power):** Cálculo e bloqueio de margem de garantia baseada na intenção operacional (Day-Trade vs. Position).
* **Controle de Concorrência:** Gerenciamento transacional robusto utilizando *Optimistic Concurrency* no SQL Server para evitar transações duplicadas concorrentes.
* **Módulo de Auditoria:** Interface administrativa para rastreabilidade, incluindo extração estruturada a partir do *Diretório Anexo JDBCC* e interface de *Controle de Versões*.

### 🛠️ Stack Tecnológica e QA
* **Core:** .NET 8, C# 12, Entity Framework Core, MS SQL Server.
* **Arquitetura:** Clean Architecture, Domain-Driven Design (DDD), CQRS Patterns.
* **Testes (SDET Focus):** xUnit, Moq, FluentAssertions para testes unitários (TDD). Preparado para integração com Testcontainers e BDD via SpecFlow.

---

## 🇺🇸 About the Project
**StockBroker** is a RESTful API built with C# (.NET 8) that simulates the order routing ecosystem and business rules of a brokerage firm operating in the B3 (Brazilian Stock Exchange).

The system is architected with a strong emphasis on software quality, domain isolation, and the prevention of financial transactional anomalies (such as Double Spending).

### ⚙️ Core Features & Business Rules
* **Validation Engine:** Strict validation of standard lots (multiples of 100) vs. fractional market orders.
* **Buying Power Management:** Calculation and reservation of margin requirements based on trading strategy (Day-Trade vs. Position).
* **Concurrency Control:** Robust transactional management using Optimistic Concurrency in SQL Server to prevent race conditions during high-frequency requests.
* **Audit Module:** Administrative interface for traceability, featuring structured extraction from the default *Diretório Anexo JDBCC* and a dedicated *Controle de Versões* (Version Control) UI.

### 🛠️ Tech Stack & QA
* **Core:** .NET 8, C# 12, Entity Framework Core, MS SQL Server.
* **Architecture:** Clean Architecture, Domain-Driven Design (DDD), CQRS Patterns.
* **Testing (SDET Focus):** xUnit, Moq, FluentAssertions for unit testing (TDD-First). Ready for Testcontainers integration and BDD specifications using SpecFlow.