using System;
using Microsoft.EntityFrameworkCore;
namespace NebulaNS.Api.DataAccess
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
    <Hash>b2a40b326c24151aaec77b1b85157c13</Hash>
</Codenesium>*/