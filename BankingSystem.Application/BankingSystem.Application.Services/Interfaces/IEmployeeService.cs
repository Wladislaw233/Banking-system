using BankingSystem.ContextDomain.Entities;
using BankingSystemServices.Models.DTO;

namespace BankingSystem.Application.Services.Interfaces;

public interface IEmployeeService
{
    public Task<Guid> AddEmployeeAsync(EmployeeDto employeeDto);

    public Task UpdateEmployeeAsync(Guid employeeId, EmployeeDto newEmployeeDto);

    public Task DeleteEmployeeAsync(Guid employeeId);

    public Task<EmployeeDto> GetEmployeeAsync(Guid employeeId);
}