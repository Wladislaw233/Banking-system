using BankingSystem.Application.Services.Interfaces;
using BankingSystem.Infrastructure.Api.Middlewares.Details;
using BankingSystemServices.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Infrastructure.Api.Controllers;

/// <summary>
///     Controller to work with employee service.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    /// <summary>
    ///     Returns the found employee by ID.
    /// </summary>
    /// <param name="employeeId">Employee guid.</param>
    /// <returns>
    ///     HTTP 200 OK and employee if employee is found.
    ///     HTTP 404 NotFound and error message if employee is not found.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetEmployee/{employeeId:guid}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(Guid employeeId)
    {
        var employee = await _employeeService.GetEmployeeAsync(employeeId);
        
        return Ok(employee);
    }

    /// <summary>
    ///     Adds a employee with the passed data in the request.
    /// </summary>
    /// <param name="employeeDto">employee data.</param>
    /// <returns>
    ///     HTTP 200 Ok and employee ID if employee is adding.
    ///     HTTP 400 BadRequest and error message if employee is not adding.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddEmployee")]
    public async Task<ActionResult<Guid>> AddEmployee(EmployeeDto employeeDto)
    {
        var employeeId = await _employeeService.AddEmployeeAsync(employeeDto);
        
        return Ok(employeeId);
    }
    
    /// <summary>
    ///     updates the data of the employee found by ID with the data passed in the request.
    /// </summary>
    /// <param name="employeeId">Employee guid.</param>
    /// <param name="employeeDto">Employee data.</param>
    /// <returns>
    ///     HTTP 200 Ok if employee is updated.
    ///     HTTP 400 BadRequest and error message if employee is not updated.
    ///     HTTP 404 NotFound and error message if employee is not found.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut("UpdateEmployee/{employeeId:guid}")]
    public async Task<ActionResult> UpdateEmployee(Guid employeeId, EmployeeDto employeeDto)
    {
        await _employeeService.UpdateEmployeeAsync(employeeId, employeeDto);
        
        return Ok();
    }
    
    /// <summary>
    ///     deletes the employee by ID.
    /// </summary>
    /// <param name="employeeId">Employee guid.</param>
    /// <returns>
    ///     HTTP 200 Ok if employee is deleted.
    ///     HTTP 400 BadRequest and error message if employee is not deleted.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteEmployeeById/{employeeId:guid}")]
    public async Task<ActionResult> DeleteEmployeeById(Guid employeeId)
    {
        await _employeeService.DeleteEmployeeAsync(employeeId);
            
        return Ok();
    }
}