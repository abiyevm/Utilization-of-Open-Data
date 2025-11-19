# Plant Monitoring API – ASP.NET Core Project

**Class:** Software Process  
**Student Work:** I have developed this project as part of my Software Process class.

---

## 1. Project Description

**Objective:**  
I have created a functional ASP.NET Core Web API project that retrieves, processes, and presents data on plant diseases and pests in Lithuania using publicly available open data from [Lithuanian Open Data Portal](https://get.data.gov.lt/datasets/gov/lzukt/Ivertis).

**Goals:**  
- Load plant disease and pest monitoring data from a public API.  
- Provide endpoints to access raw data, summaries, and aggregated insights.  
- Allow further analysis or visualization in client applications.

**Data Source:**  
- URL: [https://get.data.gov.lt/datasets/gov/lzukt/Ivertis](https://get.data.gov.lt/datasets/gov/lzukt/Ivertis)  
- Format: JSON  
- Fields include observation date, plant name, disease/pest name, harm value, violation level, and municipality.

---

## 2. Project Architecture and Structure

### Programming Language Justification
I have chosen **C# and ASP.NET Core** because:  
- I am familiar with object-oriented programming in C#.  
- ASP.NET Core is ideal for building scalable APIs.  
- It supports dependency injection, modular architecture, and easy integration with HTTP clients.

### Program Structure

**Main Modules / Classes:**

| File | Purpose |
|------|---------|
| `Models/ProblemRecord.cs` | Represents a single record of plant disease/pest observation. |
| `Models/PlantDataResponse.cs` | Wraps API response that contains `_data` list and pagination info. |
| `Services/ProblemService.cs` | Handles HTTP requests to the external API, data loading, filtering, and aggregation. |
| `Controllers/ProblemController.cs` | Provides API endpoints for clients to access processed data. |
| `Program.cs` | Configures services, HTTP client, Swagger, and routing. |

### Flow of Data (Algorithm / Pseudocode)
Start
↓
Send HTTP request to external open data API
↓
Receive raw JSON response
↓
Deserialize JSON into ProblemRecord objects
↓
Process data:
- Filter
- Aggregate
- Sort
↓
Return results through API endpoints
↓
End

---

## 3. API Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/problem/debug` | GET | I have implemented this endpoint to return the **raw JSON response** from the open data API. Useful for debugging and verifying the API structure. |
| `/api/problem/raw` | GET | Returns the **first 10 records** of plant monitoring data. I have done this to provide a quick overview of raw data for analysis. |
| `/api/problem/top-plants` | GET | Returns **top 5 plants** with the most reports of diseases or pests. I have implemented this endpoint to demonstrate aggregation and data processing. |

**Example Response – `/api/problem/top-plants`:**
```json
[
  { "Plant": "Winter wheat", "Count": 150 },
  { "Plant": "Spring wheat", "Count": 120 },
  { "Plant": "Winter rapeseed", "Count": 95 },
  { "Plant": "Sowing peas", "Count": 70 },
  { "Plant": "Spring barley", "Count": 50 }
]

4. Result Examples

Raw data preview: 10 records from /api/problem/raw endpoint.
![problems-raw](https://github.com/user-attachments/assets/3a86292e-37ab-4e53-9383-82715e4adac8)

Aggregated summary: Top 5 plants using /api/problem/top-plants endpoint.
![top-plants](https://github.com/user-attachments/assets/5b231de6-3041-4535-b7fa-b28cce87df82)

Achievement:
I have successfully demonstrated the use of open data for data aggregation and API development in ASP.NET Core, fulfilling the project goal of providing structured, usable plant monitoring insights.
