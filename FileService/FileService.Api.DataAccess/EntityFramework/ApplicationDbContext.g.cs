using Microsoft.EntityFrameworkCore;
namespace FileServiceNS.Api.DataAccess
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
    <Hash>41d61192192b6d938a7eb6af81698c51</Hash>
</Codenesium>*/