# DNA-Sequence-Analyzer-API

A RESTful API for DNA sequence analysis, built with **C# .NET 9** and **Entity Framework Core**.


## Features
*   **Analysis:** Calculates GC Content, Transcription (DNA→RNA), and Reverse Complement.
*   **Validation:** Ensures sequence integrity before processing.
*   **Persistence:** Stores analysis history using **SQLite** and **EF Core**.
*   **Reliability:** Core logic built using **Test-Driven Development (TDD)** with xUnit.

## Tech Stack
*   **Language:** C# (ASP.NET Core Web API)
*   **Database:** SQLite (Entity Framework Core)
*   **Testing:** xUnit
*   **Architecture:** Service-Repository Pattern with Dependency Injection.

## Getting Started

### Prerequisites
*   .NET 8.0 or 9.0 SDK

### Installation
1.  Clone the repository:
    ```bash
    git clone https://github.com/YOUR_USERNAME/DNA-Sequence-Analyzer-API.git
    ```
2.  Navigate to the API folder:
    ```bash
    cd DNA-Sequence-Analyzer-API
    ```
3.  Apply Database Migrations:
    ```bash
    dotnet tool install --global dotnet-ef
    dotnet ef database update
    ```
4.  Run the Server:
    ```bash
    dotnet run
    ```
5.  Open Swagger UI:
    *   Navigate to `http://localhost:5xxx/swagger` in your browser.

## Running Tests
The core logic is covered by unit tests.
```bash
dotnet test