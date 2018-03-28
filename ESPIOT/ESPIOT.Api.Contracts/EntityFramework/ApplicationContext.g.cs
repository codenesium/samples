using Microsoft.EntityFrameworkCore;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{}
		public virtual DbSet<EFDevice> Device { get; set; }
		public virtual DbSet<EFDeviceAction> DeviceAction { get; set; }
	}
}

/*<Codenesium>
    <Hash>2173baeda1223cf94403348780f6127d</Hash>
</Codenesium>*/