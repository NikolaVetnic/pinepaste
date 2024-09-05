﻿using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PinePaste.Domain.ValueObjects;

public class PasteId
{
    private static readonly Random Random = new();
    private const string Characters = "abcdefghijklmnopqrstuvwxyz0123456789";
    private const int Length = 4;

    public string Value { get; }

    // Private parameterless constructor for EF Core
    private PasteId()
    {
        Value = null!;
    }

    private PasteId(string value)
    {
        Value = value;
    }

    public static PasteId New()
    {
        var id = new StringBuilder(Length);
        
        for (var i = 0; i < Length; i++)
            id.Append(Characters[Random.Next(Characters.Length)]);

        return new PasteId(id.ToString());
    }

    public static PasteId Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be null or empty.");

        if (!IsValid(input))
            throw new ArgumentException($"Invalid PasteId: {input}");

        return new PasteId(input);
    }

    public static bool TryParse(string input, out PasteId pasteId)
    {
        // First, initialize the out parameter
        pasteId = null!;

        // Validate the input string
        if (string.IsNullOrWhiteSpace(input) || !IsValid(input))
        {
            return false;
        }

        // If the input is valid, assign a new PasteId and return true
        pasteId = new PasteId(input);
        return true;
    }


    public static bool IsValid(string input)
    {
        return input.Length == Length && Regex.IsMatch(input, @"^[a-z0-9]+$");
    }

    public override string ToString()
    {
        return Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is PasteId other)
            return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);

        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}
