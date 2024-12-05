using System.Reflection.Metadata;

public class Characters
{
    public required int Id { get; set; }
    public required string? Name { get; set; }
    public required int Age { get; set; }
    public required string? Film { get; set; }
    public required string About { get; set; }
    public string? ImageUrl { get; set; }
}