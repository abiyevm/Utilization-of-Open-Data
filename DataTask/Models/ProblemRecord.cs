using System;
using System.Text.Json.Serialization;

namespace DataTask.Models;

public class ProblemRecord
{
    [JsonPropertyName("_id")]
    public string VdaId { get; set; } = string.Empty;

    [JsonPropertyName("stebesenos_data")]
    public DateTime? ObservationDate { get; set; }

    [JsonPropertyName("augalo_pavadinimas")]
    public string? PlantName { get; set; }

    [JsonPropertyName("ligos_kenkejo_pavadinimas")]
    public string? DiseasePestName { get; set; }

    [JsonPropertyName("ligos_kenkejo_pavadinimas_lot")]
    public string? DiseasePestNameLot { get; set; }

    [JsonPropertyName("kenksmingumas")]
    public int? HarmValue { get; set; }

    [JsonPropertyName("pazeidimo_lygis")]
    public string? ViolationLevel { get; set; }

    [JsonPropertyName("savivaldybe")]
    public string? Municipality { get; set; }
}