using Microsoft.EntityFrameworkCore;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{}
		public virtual DbSet<EFBucket> Bucket { get; set; }
		public virtual DbSet<EFFile> File { get; set; }
		public virtual DbSet<EFFileType> FileType { get; set; }
	}
}

/*<Codenesium>
    <Hash>5040cbaa876204855a9f50700035fb1e</Hash>
</Codenesium>*/