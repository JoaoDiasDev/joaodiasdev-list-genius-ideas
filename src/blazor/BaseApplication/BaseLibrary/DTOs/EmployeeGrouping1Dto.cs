﻿namespace BaseLibrary.DTOs;

public class EmployeeGrouping1Dto
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Address { get; set; } = string.Empty;
    [Required] public string TelephoneNumber { get; set; } = string.Empty;
    [Required] public string Photo { get; set; } = string.Empty;
    [Required] public string CivilId { get; set; } = string.Empty;
    [Required] public string FileNumber { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;

}