using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Models;

namespace SMS.ModelConfigration
{
	public class SchoolConfiration : IEntityTypeConfiguration<School>
	{
		public void Configure(EntityTypeBuilder<School> builder)
		{
			builder.ToTable(nameof(School));
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.Name).HasMaxLength(100).IsRequired();
			builder.Property(x=>x.Roll).HasMaxLength(100).IsRequired();
			builder.Property(x=>x.Age).HasMaxLength(100).IsRequired();
			builder.Property(x=>x.Address).HasMaxLength(100).IsRequired();
		}
	}
}
