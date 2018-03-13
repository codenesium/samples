using Microsoft.EntityFrameworkCore;
namespace NebulaNS.Api.Contracts
{
	public partial class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{}
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
	}
}

/*<Codenesium>
    <Hash>28b0f4a0a527330ba44abcd18e7469c6</Hash>
</Codenesium>*/