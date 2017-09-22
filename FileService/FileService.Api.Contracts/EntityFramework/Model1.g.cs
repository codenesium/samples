using System.Data.Entity;
using System.Data.Entity.SqlServer;
namespace FileServiceNS.Api.Contracts
{
	public partial class Model1:DbContext
	{
		public Model1()
			: base("name=FileServiceDBConnection")
		{
			Database.SetInitializer<Model1>(null); // disable migrations
			this.Configuration.LazyLoadingEnabled = false; //disable lazy loading
		}
		public virtual DbSet<Bucket> Bucket { get; set; }
		public virtual DbSet<File> File { get; set; }
		public virtual DbSet<FileType> FileType { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{}
	}

	internal static class MissingDllHack
	{
		// Must reference a type in EntityFramework.SqlServer.dll so that this dll will be
		// included in the output folder of referencing projects without requiring a direct
		// dependency on Entity Framework. See http://stackoverflow.com/a/22315164/1141360.
		private static SqlProviderServices instance = SqlProviderServices.Instance;
	}
}

/*<Codenesium>
    <Hash>73575e76fc9903d6f696291d9c6a31b2</Hash>
</Codenesium>*/