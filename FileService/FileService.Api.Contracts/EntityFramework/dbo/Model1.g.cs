using System.Data.Entity;
using System.Data.Entity.SqlServer;
namespace FileServiceNS.Api.Contracts
{
	public partial class Model1:DbContext
	{
		public Model1()
			: base("name=FileServiceDBConnection")
		{
			Database.SetInitializer<Model1>(null);
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
    <Hash>f3b1efdb2892168e3d523bfedd79fd3c</Hash>
</Codenesium>*/