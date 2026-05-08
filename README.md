# Restaurant Collection API — .NET 6 / C#

A fully functional RESTful API built with .NET 6 and C# for managing a restaurant
directory across multiple cities. Implements complete CRUD operations, query filtering,
and data sorting — following REST best practices and clean architecture patterns.

## Features

- Full **CRUD** operations on restaurant data
- **Query filtering** by city and by unique ID
- **Sorting** by average user rating
- **Unit test suite** included (`RestaurantCollection.Tests`)
- Clean JSON request/response contract
- Proper HTTP status codes per operation (201, 200, 204)

## Tech Stack

| | |
|---|---|
| Framework | .NET 6 / ASP.NET Core Web API |
| Language | C# |
| Architecture | RESTful API |
| Testing | NUnit (RestaurantCollection.Tests) |

## Project Structure

```
RestaurantCollection/
├── RestaurantCollection/          # Main API project
├── RestaurantCollection.Tests/    # Unit test suite (read-only specs)
├── reports/                       # Test execution reports
├── RestaurantCollection.sln
└── README.md
```

## API Endpoints

| Method | Endpoint | Description | Status Code |
|--------|----------|-------------|-------------|
| `POST` | `/restaurant` | Add a new restaurant | 201 |
| `GET` | `/restaurant` | Get all restaurants | 200 |
| `GET` | `/restaurant/query?city={city}` | Get restaurants by city | 200 |
| `GET` | `/restaurant/query?id={id}` | Get restaurant by ID | 200 |
| `PUT` | `/restaurant/{id}` | Update rating and votes | 200 |
| `DELETE` | `/restaurant/{id}` | Delete restaurant by ID | 204 |
| `GET` | `/restaurant/sort` | Get restaurants sorted by rating | 200 |

## Data Model

```json
{
  "id": "1",
  "name": "Byg Company",
  "city": "Miami",
  "estimatedCost": 1600,
  "averageRating": "4.9",
  "votes": "16203"
}
```

## Getting Started

```bash
git clone https://github.com/Kerwin-Core/RestaurantCollection
cd RestaurantCollection
dotnet restore
dotnet run --project RestaurantCollection
```

## Running Tests

```bash
dotnet test RestaurantCollection.Tests
```

## Example Requests

**Add a restaurant:**
```bash
curl -X POST https://localhost:5001/restaurant \
  -H "Content-Type: application/json" \
  -d '{"name":"Byg Company","city":"Miami","estimatedCost":1600,"averageRating":"4.9","votes":"16203"}'
```

**Get all restaurants in Miami:**
```bash
curl https://localhost:5001/restaurant/query?city=Miami
```

**Get sorted by rating:**
```bash
curl https://localhost:5001/restaurant/sort
```

## About the Author

Kerwin Arias — Senior Software Developer with 35+ years of experience in C#/.NET,
currently building FHIR-based microservices and clinical EMR systems at Modernizing Medicine.

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/kerwin-alexander-arias-36b8a3170)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Kerwin-Core)
