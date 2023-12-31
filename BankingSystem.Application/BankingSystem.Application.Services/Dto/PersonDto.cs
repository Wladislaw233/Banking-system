﻿using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Application.Services.Dto;

/// <summary>
///     Person data transfer model for API.
/// </summary>
public class PersonDto
{
    /// <summary>
    ///     Person firstname.
    /// </summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    ///     Person lastname.
    /// </summary>
    [Required]
    public string LastName { get; set; }

    /// <summary>
    ///     Person date of birth.
    /// </summary>
    [Required]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    ///     Person age.
    /// </summary>
    [Required]
    public int Age { get; set; }

    /// <summary>
    ///     Person bonus amount.
    /// </summary>
    public decimal Bonus { get; set; }
}