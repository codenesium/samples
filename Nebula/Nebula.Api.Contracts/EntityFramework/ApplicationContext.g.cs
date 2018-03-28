using Microsoft.EntityFrameworkCore;
namespace NebulaNS.Api.Contracts
{
	public partial class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{}
		public virtual DbSet<EFChain> Chain { get; set; }
		public virtual DbSet<EFChainStatus> ChainStatus { get; set; }
		public virtual DbSet<EFClasp> Clasp { get; set; }
		public virtual DbSet<EFLink> Link { get; set; }
		public virtual DbSet<EFLinkLog> LinkLog { get; set; }
		public virtual DbSet<EFLinkStatus> LinkStatus { get; set; }
		public virtual DbSet<EFMachine> Machine { get; set; }
		public virtual DbSet<EFMachineRefTeam> MachineRefTeam { get; set; }
		public virtual DbSet<EFOrganization> Organization { get; set; }
		public virtual DbSet<EFTeam> Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>c95b79a9592e157ab342b71c7a8ca5a5</Hash>
</Codenesium>*/