using Microsoft.EntityFrameworkCore;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{}
		public virtual DbSet<EFDevice> Devices { get; set; }
		public virtual DbSet<EFDeviceAction> DeviceActions { get; set; }
	}
}

/*<Codenesium>
    <Hash>ec838262c434114bf397345a15b3a343</Hash>
</Codenesium>*/