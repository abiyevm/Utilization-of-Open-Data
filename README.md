# 🌱 Plant Monitoring API – ASP.NET Core Project

**Class:** Software Process  
**Student Work:** Developed as part of my Software Process class assignment.

---

## 1. Project Description

**Objective:**  
This ASP.NET Core Web API project retrieves, processes, and presents data on plant diseases and pests in Lithuania using publicly available data from the [Lithuanian Open Data Portal](https://get.data.gov.lt/datasets/gov/lzukt/Ivertis).

**Goals:**  
- Load plant disease and pest monitoring data from a public API.  
- Provide endpoints to access raw data, summaries, and aggregated insights.  
- Allow further analysis or visualization in client applications.

**Data Source:**  
- URL: [https://get.data.gov.lt/datasets/gov/lzukt/Ivertis](https://get.data.gov.lt/datasets/gov/lzukt/Ivertis)  
- Format: JSON  
- Fields: observation date, plant name, disease/pest name, harm value, violation level, municipality.

---

## 2. Project Architecture and Structure

### Programming Language Justification
I chose **C# and ASP.NET Core** because:  
- Familiarity with object-oriented programming in C#.  
- ASP.NET Core is ideal for scalable API development.  
- It supports dependency injection, modular architecture, and easy HTTP integration.

### Program Structure

| File | Purpose |
|------|---------|
| `Models/ProblemRecord.cs` | Represents a single plant disease/pest observation record. |
| `Models/PlantDataResponse.cs` | Wraps API response containing `_data` list and pagination info. |
| `Services/ProblemService.cs` | Handles HTTP requests, data loading, filtering, and aggregation. |
| `Controllers/ProblemController.cs` | Provides API endpoints for clients to access processed data. |
| `Program.cs` | Configures services, HTTP client, Swagger, and routing. |


---

## 3. API Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/problem/debug` | GET | Returns raw JSON from the open data API for debugging. |
| `/api/problem/raw` | GET | Returns first 10 records of plant monitoring data. |
| `/api/problem/top-plants` | GET | Returns top 5 plants with most disease/pest reports. |

**Example Response – `/api/problem/top-plants`:**
```json
[
  { "Plant": "Winter wheat", "Count": 150 },
  { "Plant": "Spring wheat", "Count": 120 },
  { "Plant": "Winter rapeseed", "Count": 95 },
  { "Plant": "Sowing peas", "Count": 70 },
  { "Plant": "Spring barley", "Count": 50 }
]

## Result Examples
Raw Data Preview: 10
![problems-raw](https://github.com/user-attachments/assets/fa4c39ac-ed1f-4589-8192-387028f8acb3)

records from /api/problem/raw endpoint.
![top-plants](https://github.com/user-attachments/assets/583305b0-c1b2-43e5-90e5-d2150b80e0b4)

Aggregated Summary: Top 5 plants using /api/problem/top-plants.

5. Achievement

This project demonstrates the use of open data for data aggregation and API development in ASP.NET Core. It provides structured, usable plant monitoring insights suitable for analysis and visualization.
