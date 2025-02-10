using ClenaArchitecture.Domain.Employees;
using FluentValidation;
using GenericRepository;
using Mapster;
using MediatR;
using TS.Result;

namespace CleanArchitecture.Application.Employees;

public sealed record EmployeeCreateCommand(
    string FirstName,
    string LastName,
    DateOnly BirthOfDate,
    decimal Salary,
    Address? Address,
    PersonalInformation PersonalInformation) : IRequest<Result<string>>;

public sealed class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
{
    public EmployeeCreateCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş olamaz").MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş olamaz").MinimumLength(3).WithMessage("Soyad en az 3 karakter olmalıdır");
        RuleFor(x => x.BirthOfDate).NotEmpty().WithMessage("Doğum tarihi alanı boş olamaz");
        RuleFor(x => x.Salary).NotEmpty().WithMessage("Maaş alanı boş olamaz");
        RuleFor(x => x.PersonalInformation).NotNull().WithMessage("Kişisel bilgi alanı boş olamaz");
        RuleFor(x => x.PersonalInformation.TcNo).NotEmpty().WithMessage("TC no alanı boş olamaz").MinimumLength(11).MaximumLength(11);
    }
}

internal sealed class EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) : IRequestHandler<EmployeeCreateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
    {
        var employeeExist = await employeeRepository.AnyAsync(x => x.PersonalInformation.TcNo == request.PersonalInformation.TcNo, cancellationToken);

        if (employeeExist)
        {
            return Result<string>.Failure("Bu TC no daha önce kaydedilmiş");
        }

        Employee employee = request.Adapt<Employee>();
        employeeRepository.Add(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel Kaydı Başarıyla Oluşturuldu";
    }
}

