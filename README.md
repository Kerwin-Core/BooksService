# Books Service API — .NET 6 / ASP.NET Core Web API

A .NET 6 Web API implementing robust **model validation** patterns for a book
catalog service. Demonstrates best-practice validation architecture — logic lives
in the model layer, keeping controllers clean and testable.

## Features

- **Model-layer validation** — all rules enforced in `Models/Book.cs`, not in controllers
- **Detailed error responses** — descriptive 400 messages per field violation
- **Integration test suite** — `BooksService.Tests/IntegrationTests.cs`
- **Clean architecture** — WebAPI project fully separated from test project
- Proper HTTP status codes (200 success / 400 validation failure)

## Tech Stack

| | |
|---|---|
| Framework | .NET 6 / ASP.NET Core Web API |
| Language | C# |
| Architecture | RESTful Web API with model validation |
| Testing | Integration Tests (BooksService.Tests) |

## Project Structure

```
BooksService/
├── BooksService.WebAPI/           # Main Web API project
│   ├── Controllers/
│   │   └── BooksController.cs    # REST controller (read-only spec)
│   └── Models/
│       └── Book.cs               # Model with full validation logic
├── BooksService.Tests/
│   └── IntegrationTests.cs       # Integration test suite
├── reports/                       # Test execution reports
└── BooksService.WebAPI.sln
```

## API Endpoint

| Method | Endpoint | Success | Failure |
|--------|----------|---------|---------|
| `POST` | `/api/books` | 200 OK | 400 Bad Request |

## Data Model

```json
{
  "title": "Initial Professional Development for Civil Engineers",
  "author": "Patrick Waterhouse",
  "publicationDate": "2017-09-08T19:04:14.480Z"
}
```

## Validation Rules

| Field | Rules | Error Message |
|-------|-------|---------------|
| `title` | Required · 5–255 chars · First letter uppercase | `"Title is invalid: ..."` |
| `author` | Required · 3–30 chars · First letter uppercase | `"Author is invalid: ..."` |
| `publicationDate` | Required · After 01/01/1900 · Before today | `"PublicationDate is invalid: ..."` |

## Getting Started

```bash
git clone https://github.com/Kerwin-Core/BooksService
cd BooksService
dotnet restore
dotnet run --project BooksService.WebAPI
```

## Running Tests

```bash
dotnet test BooksService.Tests
```

## Example Requests

**Valid book — returns 200:**
```bash
curl -X POST https://localhost:5001/api/books \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Initial Professional Development for Civil Engineers",
    "author": "Patrick Waterhouse",
    "publicationDate": "2017-09-08T19:04:14.480Z"
  }'
```

**Invalid book — returns 400:**
```bash
curl -X POST https://localhost:5001/api/books \
  -H "Content-Type: application/json" \
  -d '{
    "title": "bad",
    "author": "x",
    "publicationDate": "1800-01-01T00:00:00.000Z"
  }'
```

**400 Response example:**
```json
{
  "errors": [
    "Title is invalid: Title must contain a minimum of 5 characters and a maximum of 255, and the first letter should be in upper case",
    "Author is invalid: Author must contain a minimum of 3 characters and a maximum of 30, and the first letter should be in upper case",
    "PublicationDate is invalid: PublicationDate must be after 01/01/1900 and before the current date"
  ]
}
```

## About the Author

Kerwin Arias — Senior Software Developer with 35+ years of experience in C#/.NET,
currently building FHIR-based microservices and clinical EMR systems at Modernizing Medicine.

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/kerwin-alexander-arias-36b8a3170)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Kerwin-Core)
