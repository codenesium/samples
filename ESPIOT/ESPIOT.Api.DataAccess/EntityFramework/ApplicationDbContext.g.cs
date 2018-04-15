using Microsoft.EntityFrameworkCore;
namespace ESPIOTNS.Api.DataAccess
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
    <Hash>f7105133663369b8108f5555d6380197</Hash>
</Codenesium>*/