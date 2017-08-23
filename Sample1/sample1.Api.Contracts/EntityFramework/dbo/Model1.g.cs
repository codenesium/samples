using System.Data.Entity;
namespace sample1NS.Api.Contracts
{
	public partial class Model1:DbContext
	{
		public Model1()
			: base("name=sample1DBConnection")
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
}

/*<Codenesium>
    <Hash>d49eabb4a4f14d9e2655871d74aef0b3</Hash>
</Codenesium>*/