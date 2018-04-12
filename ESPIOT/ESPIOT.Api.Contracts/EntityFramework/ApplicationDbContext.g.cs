using Microsoft.EntityFrameworkCore;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}
		public virtual DbSet<EFDevice> Devices { get; set; }

		public virtual DbSet<EFDeviceAction> DeviceActions { get; set; }
	}
}

/*<Codenesium>
    <Hash>1ce6f55918c4cfb08bc3f4a5c63af024</Hash>
</Codenesium>*/