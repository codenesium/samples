using Microsoft.EntityFrameworkCore;
namespace NebulaNS.Api.Contracts
{
	public partial class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}
		public virtual DbSet<EFChain> Chains { get; set; }

		public virtual DbSet<EFChainStatus> ChainStatus { get; set; }

		public virtual DbSet<EFClasp> Clasps { get; set; }

		public virtual DbSet<EFLink> Links { get; set; }

		public virtual DbSet<EFLinkLog> LinkLogs { get; set; }

		public virtual DbSet<EFLinkStatus> LinkStatus { get; set; }

		public virtual DbSet<EFMachine> Machines { get; set; }

		public virtual DbSet<EFMachineRefTeam> MachineRefTeams { get; set; }

		public virtual DbSet<EFOrganization> Organizations { get; set; }

		public virtual DbSet<EFTeam> Teams { get; set; }
	}
}

/*<Codenesium>
    <Hash>4bbff97f94264438422de730459ce877</Hash>
</Codenesium>*/