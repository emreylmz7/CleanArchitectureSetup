namespace ClenaArchitecture.Domain.Employees;

public sealed record Address
{
    public string? Street { get; set; }
    public string? City { get; set; } 
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; } 
}
