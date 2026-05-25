using System.ComponentModel.DataAnnotations;

namespace Course.CloudNativeDev.Api.Entities;

public class Gender : BaseEntity
{
    [StringLength(50)]
    public string Name { get; set; } = null!;
}