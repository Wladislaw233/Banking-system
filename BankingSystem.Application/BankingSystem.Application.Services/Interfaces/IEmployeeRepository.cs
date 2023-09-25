using BankingSystem.ContextDomain.Entities;

namespace BankingSystem.Application.Services.Interfaces;

public interface IEmployeeRepository
{
    Task AddEmployeeAsync(Employee employee);

    Task UpdateEmployeeAsync(Employee employee);

    Task DeleteEmployeeAsync(Guid employeeId);

    Task<Employee> GetEmployeeAsync(Guid employeeId);
}