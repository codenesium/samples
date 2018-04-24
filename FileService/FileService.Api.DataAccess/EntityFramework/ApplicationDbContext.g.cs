using System;
using Microsoft.EntityFrameworkCore;
namespace FileServiceNS.Api.DataAccess
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

		public virtual DbSet<EFBucket> Buckets { get; set; }

		public virtual DbSet<EFFile> Files { get; set; }

		public virtual DbSet<EFFileType> FileTypes { get; set; }
	}
}

/*<Codenesium>
    <Hash>fad6f8ce11f9368abe5129841b8a38ba</Hash>
</Codenesium>*/