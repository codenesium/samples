using System;
using Microsoft.EntityFrameworkCore;
namespace ESPIOTNS.Api.DataAccess
{
	public partial class ApplicationDbContext: DbContext
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{}

		public void SetUserId(Guid userId)
		{
			if(userId == default (Guid))
			{
				throw new ArgumentException("UserId cannot be a default value");
			}
			this.UserId = userId;
		}

		public void SetTenantId(int tenantId)
		{
			if(tenantId <= 0)
			{
				throw new ArgumentException("TenantId must be greater than 0");
			}
			this.TenantId = tenantId;
		}

		public virtual DbSet<EFDevice> Devices { get; set; }

		public virtual DbSet<EFDeviceAction> DeviceActions { get; set; }
	}
}

/*<Codenesium>
    <Hash>0f9a4be7fc6f5949f0db0ba2cc04633d</Hash>
</Codenesium>*/