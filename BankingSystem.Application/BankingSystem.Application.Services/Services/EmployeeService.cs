using AutoMapper;
using BankingSystem.Application.Services.Interfaces;
using BankingSystem.ContextDomain.Entities;
using BankingSystemServices.Models.DTO;

namespace BankingSystem.Application.Services.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<Guid> AddEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);

        await _employeeRepository.AddEmployeeAsync(employee);

        return employee.EmployeeId;
    }

    public async Task UpdateEmployeeAsync(Guid employeeId, EmployeeDto newEmployeeDto)
    {
        var employee = new Employee();

        var employeeTuple = new Tuple<EmployeeDto, Guid>(newEmployeeDto, employeeId);
        
        _mapper.Map(employeeTuple, employee);

        await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(Guid employeeId)
    {
        await _employeeRepository.DeleteEmployeeAsync(employeeId);
    }

    public async Task<EmployeeDto> GetEmployeeAsync(Guid employeeId)
    {
        var employee = await _employeeRepository.GetEmployeeAsync(employeeId);
        return _mapper.Map<EmployeeDto>(employee);
    }
}