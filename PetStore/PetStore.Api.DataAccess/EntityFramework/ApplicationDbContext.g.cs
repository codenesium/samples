using System;
using Microsoft.EntityFrameworkCore;
namespace PetStoreNS.Api.DataAccess
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

		public virtual DbSet<EFBreed> Breeds { get; set; }

		public virtual DbSet<EFPaymentType> PaymentTypes { get; set; }

		public virtual DbSet<EFPen> Pens { get; set; }

		public virtual DbSet<EFPet> Pets { get; set; }

		public virtual DbSet<EFSale> Sales { get; set; }

		public virtual DbSet<EFSpecies> Species { get; set; }
	}
}

/*<Codenesium>
    <Hash>af2853014f966ddd79143f70a3ee2142</Hash>
</Codenesium>*/