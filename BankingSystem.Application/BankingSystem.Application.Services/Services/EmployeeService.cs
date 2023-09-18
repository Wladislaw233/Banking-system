using AutoMapper;
using BankingSystem.Application.Services.Interfaces;
using BankingSystem.ContextDomain.Entities;
using BankingSystem.ContextDomain.Exceptions;
using BankingSystem.Infrastructure.Data.Context;
using BankingSystemServices.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Application.Services.Services;

public class EmployeeService : IEmployeeService
{
    private readonly BankingSystemDbContext _bankingSystemDbContext;
    private readonly IMapper _mapper;

    public EmployeeService(BankingSystemDbContext bankingSystemDbContext, IMapper mapper)
    {
        _bankingSystemDbContext = bankingSystemDbContext;
        _mapper = mapper;
    }

    public async Task<Guid> AddEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);

        if (await EmployeeContainsInDatabase(employee))
            throw new ArgumentException("Employee with such data already exists in the banking system.",
                nameof(employeeDto));
        
        await _bankingSystemDbContext.Employees.AddAsync(employee);

        await _bankingSystemDbContext.SaveChangesAsync();

        return employee.EmployeeId;
    }

    public async Task UpdateEmployeeAsync(Guid employeeId, EmployeeDto newEmployeeDto)
    {
        var employee = await GetEmployeeByIdAsync(employeeId);

        var employeeTuple = new Tuple<EmployeeDto, Guid>(newEmployeeDto, employeeId);
        
        _mapper.Map(employeeTuple, employee);
        
        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Guid employeeId)
    {
        var bankEmployee = await GetEmployeeByIdAsync(employeeId);

        _bankingSystemDbContext.Employees.Remove(bankEmployee);

        await _bankingSystemDbContext.SaveChangesAsync();
    }

    public async Task<EmployeeDto> GetEmployeeAsync(Guid employeeId)
    {
        var employee = await GetEmployeeByIdAsync(employeeId);
        return _mapper.Map<EmployeeDto>(employee);
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
    
    private async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
    {
        var employee = await _bankingSystemDbContext.Employees.SingleOrDefaultAsync(employee =>
            employee.EmployeeId.Equals(employeeId));

        if (employee == null)
            throw new ValueNotFoundException($"The employee with identifier {employeeId} does not exist!");

        return employee;
    }
}