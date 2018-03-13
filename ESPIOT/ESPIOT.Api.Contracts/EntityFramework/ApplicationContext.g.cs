using Microsoft.EntityFrameworkCore;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{}
		public virtual DbSet<Device> Device { get; set; }
		public virtual DbSet<DeviceAction> DeviceAction { get; set; }
	}
}

/*<Codenesium>
    <Hash>6a217946155ade145374613b58569319</Hash>
</Codenesium>*/