using BankingSystem.Application.Services.Dto;
using BankingSystem.Application.Services.Interfaces;
using BankingSystem.Infrastructure.Api.Middlewares.Details;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Infrastructure.Api.Controllers;

/// <summary>
///     Controller to work with client service.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    /// <summary>
    ///     Returns the found client by ID.
    /// </summary>
    /// <param name="clientId">Client guid.</param>
    /// <returns>
    ///     HTTP 200 OK and client if client is found.
    ///     HTTP 404 NotFound and error message if client is not found.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("GetClient/{clientId:guid}")]
    public async Task<ActionResult<ClientDto>> GetClient(Guid clientId)
    {
        var client = await _clientService.GetClientAsync(clientId);
        
        return Ok(client);
    }

    /// <summary>
    ///     Adds a client with the passed data in the request.
    /// </summary>
    /// <param name="clientDto">employee data.</param>
    /// <returns>
    ///     HTTP 200 Ok and client ID if client is adding.
    ///     HTTP 400 BadRequest and error message if client is not adding.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("AddClient")]
    public async Task<ActionResult<Guid>> AddClient(ClientDto clientDto)
    {
        var client = await _clientService.AddClientAsync(clientDto);
        
        return Ok(client);
    }

    /// <summary>
    ///     Updates the data of the client found by ID with the data passed in the request.
    /// </summary>
    /// <param name="clientId">Client guid.</param>
    /// <param name="clientDto">Client data.</param>
    /// <returns>
    ///     HTTP 200 Ok if client is updated.
    ///     HTTP 400 BadRequest and error message if client is not updated.
    ///     HTTP 404 NotFound and error message if client is not found.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpPut("UpdateClient/{clientId:guid}")]
    public async Task<ActionResult> UpdateClient(Guid clientId, ClientDto clientDto)
    {
        await _clientService.UpdateClientAsync(clientId, clientDto);
        
        return Ok();
    }

    /// <summary>
    ///     Deletes the client by ID.
    /// </summary>
    /// <param name="clientId">client guid.</param>
    /// <returns>
    ///     HTTP 200 Ok if client is deleted.
    ///     HTTP 400 BadRequest and error message if client is not deleted.
    ///     HTTP 500 InternalServerError and error massage if an unexpected error occurs on the server.
    /// </returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [HttpDelete("DeleteClientById/{clientId:guid}")]
    public async Task<ActionResult> DeleteClientById(Guid clientId)
    {
        await _clientService.DeleteClientAsync(clientId);
        
        return Ok();
    }
}