using AutoMapper;
using BankingSystem.Application.Services.Interfaces;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.ContextDomain.Exceptions;
using BankingSystem.Infrastructure.Data.Context;
using BankingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Repositories.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IMapper _mapper;
    private readonly BankingSystemDbContext _bankingSystemDbContext;

    public EmployeeRepository(IMapper mapper, BankingSystemDbContext bankingSystemDbContext)
    {
        _mapper = mapper;
        _bankingSystemDbContext = bankingSystemDbContext;
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        if (await EmployeeContainsInDatabase(employee))
            throw new ArgumentException("Employee with such data already exists in the banking system.",
                nameof(employee));
        
        var employeeDb = _mapper.Map<EmployeeDb>(employee);
        
        await _bankingSystemDbContext.Employees.AddAsync(employeeDb);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var employeeDb = _mapper.Map<EmployeeDb>(employee);

        _bankingSystemDbContext.Employees.Update(employeeDb);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Guid employeeId)
    {
        var employeeDb = await GetEmployeeByIdAsync(employeeId);

        _bankingSystemDbContext.Employees.Remove(employeeDb);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task<Employee> GetEmployeeAsync(Guid employeeId)
    {
        var employeeDb = await GetEmployeeByIdAsync(employeeId);
        return _mapper.Map<Employee>(employeeDb);
    }

    private async Task<EmployeeDb> GetEmployeeByIdAsync(Guid employeeId)
    {
        var employee = await _bankingSystemDbContext.Employees.SingleOrDefaultAsync(employee =>
            employee.EmployeeId.Equals(employeeId));

        if (employee == null)
            throw new ValueNotFoundException($"The employee with identifier {employeeId} does not exist!");

        return employee;
    }
    
    private async Task<bool> EmployeeContainsInDatabase(Employee employee)
    {
        return await _bankingSystemDbContext.Employees.AnyAsync(e => e.FirstName == employee.FirstName 
                                                                     && e.LastName == employee.LastName 
                                                                     && e.PhoneNumber == employee.PhoneNumber
                                                                     && e.Address == employee.Address
                                                                     && e.Email == employee.Email
                                                                     && e.DateOfBirth.Equals(employee.DateOfBirth));
    }
}