using System;

namespace Backend.Services.DataTransferObjects;

public class ServerRecipeInstruction
{
    public int Ordinal { get; set; } = 0;

    public string? InstructionMessage { get; set; }
    public string Instruction { get; set; } = "";
}
