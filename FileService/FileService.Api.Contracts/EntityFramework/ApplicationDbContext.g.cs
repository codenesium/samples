using Microsoft.EntityFrameworkCore;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}
		public virtual DbSet<EFBucket> Buckets { get; set; }

		public virtual DbSet<EFFile> Files { get; set; }

		public virtual DbSet<EFFileType> FileTypes { get; set; }
	}
}

/*<Codenesium>
    <Hash>023b26ef088fda2e60b364ac34f40094</Hash>
</Codenesium>*/