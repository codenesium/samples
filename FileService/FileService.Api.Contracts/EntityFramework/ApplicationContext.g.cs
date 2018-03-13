using Microsoft.EntityFrameworkCore;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{}
		public virtual DbSet<Bucket> Bucket { get; set; }
		public virtual DbSet<File> File { get; set; }
		public virtual DbSet<FileType> FileType { get; set; }
	}
}

/*<Codenesium>
    <Hash>f9917195acc1c2c9d2e0e02bb2a5ed71</Hash>
</Codenesium>*/