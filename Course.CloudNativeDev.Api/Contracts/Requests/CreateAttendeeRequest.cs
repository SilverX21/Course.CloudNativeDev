using System.ComponentModel.DataAnnotations;

namespace Course.CloudNativeDev.Api.Contracts.Requests;

public class CreateAttendeeRequest
{
    [Required]
    [StringLength(50)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public required string LastName { get; set; }

    [Required]
    [StringLength(150)]
    public required string EmailAddress { get; set; }

    [StringLength(14)]
    public string? PhoneNumber { get; set; }

    [StringLength(150)]
    public string? CompanyName { get; set; }

    [Required]
    public Guid GenderId { get; set; }

    [Required]
    public Guid JobRoleId { get; set; }

    [Required]
    public Guid ReferalSourceId { get; set; }
}
