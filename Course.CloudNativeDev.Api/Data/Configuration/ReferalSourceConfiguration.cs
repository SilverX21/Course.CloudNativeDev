using Course.CloudNativeDev.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Course.CloudNativeDev.Api.Data.Configuration;

public class ReferalSourceConfiguration : IEntityTypeConfiguration<ReferalSource>
{
    public void Configure(EntityTypeBuilder<ReferalSource> builder)
    {
        builder.HasData(
            new ReferalSource { Id = Guid.Parse("E51F98BB-D9EE-5496-B145-FB6891046F7D"), Name = "Internet Advertisement" },
            new ReferalSource { Id = Guid.Parse("51BA96AA-167E-4CFF-BCB4-0C68F1555086"), Name = "Television" },
            new ReferalSource { Id = Guid.Parse("51BA96AA-167E-4CFF-BCA4-0C68F1665034"), Name = "Newspaper Article" },
            new ReferalSource { Id = Guid.Parse("51BA96AA-167E-4CFF-BCA4-0C68F4655034"), Name = "Other" }
        );
    }
}