using System.Reflection.Metadata;

public class Characters
{
    public required int Id { get; set; }
    public required string? Name { get; set; }
    public required int Age { get; set; }
    public required string? Film { get; set; }
    public Blob image { get; set; }
    public required string About { get; set; }
}