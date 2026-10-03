using System;

namespace Backend.Services.DataTransferObjects;

public class ServerIngredient
{
    public string? FractionMessage { get; set; }
    public int? Fraction { get; set; }
    public string? MeasurementUnit { get; set; }
    public int? Quantity { get; set; }

    public string? ItemNameMessage { get; set; }
    public string ItemName { get; set; } = "";
}
