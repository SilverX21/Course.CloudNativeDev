using System.ComponentModel.DataAnnotations;

namespace Course.CloudNativeDev.Api.Contracts.Requests;

public class CreateJobRoleRequest
{
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
}
