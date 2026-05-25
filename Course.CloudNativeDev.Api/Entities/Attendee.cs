using System.ComponentModel.DataAnnotations;

namespace Course.CloudNativeDev.Api.Entities;

public class Attendee : BaseEntity
{
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string LAstNAme { get; set; }

    [StringLength(150)]
    public string EmailAddress { get; set; }

    [StringLength(14)]
    public string PhoneNumber { get; set; }

    [StringLength(150)]
    public string CompanyName { get; set; }

    public ReferalSource? ReferalSource { get; set; }
    public Guid ReferalSourceId { get; set; }

    public JobRole? JobRole { get; set; }
    public Guid JobRoleId { get; set; }

    public Gender? Gender { get; set; }
    public Guid GenderId { get; set; }
}