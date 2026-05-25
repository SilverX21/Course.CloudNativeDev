using Course.CloudNativeDev.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Course.CloudNativeDev.Api.Data.Configuration;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasData(
            new Gender { Id = Guid.Parse("E51F98BB-D9EE-4496-B195-FB6891046F7D"), Name = "Male" },
            new Gender { Id = Guid.Parse("51BA96AA-167E-4CFF-BCA4-0C68D1555086"), Name = "Female" }
        );
    }
}