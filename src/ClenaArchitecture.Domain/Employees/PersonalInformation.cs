namespace ClenaArchitecture.Domain.Employees;

public sealed record PersonalInformation
{
    public string TcNo { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
}