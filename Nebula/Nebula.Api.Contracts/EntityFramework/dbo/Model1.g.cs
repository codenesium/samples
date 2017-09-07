using System.Data.Entity;
using System.Data.Entity.SqlServer;
namespace NebulaNS.Api.Contracts
{
	public partial class Model1:DbContext
	{
		public Model1()
			: base("name=NebulaDBConnection")
		{
			Database.SetInitializer<Model1>(null);
		}
		public virtual DbSet<Chain> Chain { get; set; }
		public virtual DbSet<ChainStatus> ChainStatus { get; set; }
		public virtual DbSet<Clasp> Clasp { get; set; }
		public virtual DbSet<Link> Link { get; set; }
		public virtual DbSet<LinkLog> LinkLog { get; set; }
		public virtual DbSet<LinkStatus> LinkStatus { get; set; }
		public virtual DbSet<Machine> Machine { get; set; }
		public virtual DbSet<MachineRefTeam> MachineRefTeam { get; set; }
		public virtual DbSet<Organization> Organization { get; set; }
		public virtual DbSet<Team> Team { get; set; }

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
    <Hash>6ca9af075402dc84eede588e9e6fc868</Hash>
</Codenesium>*/