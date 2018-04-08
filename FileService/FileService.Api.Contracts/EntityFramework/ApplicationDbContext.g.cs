using Microsoft.EntityFrameworkCore;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{}
		public virtual DbSet<EFBucket> Buckets { get; set; }
		public virtual DbSet<EFFile> Files { get; set; }
		public virtual DbSet<EFFileType> FileTypes { get; set; }
	}
}

/*<Codenesium>
    <Hash>d6e1a85edbe7b0b11694b9626e2a04fa</Hash>
</Codenesium>*/