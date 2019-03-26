using Codenesium.DataConversionExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	public class ApplicationDbContext : AbstractApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor accessor)
			: base(options)
		{
			// accessoror accessor.HttpContext may be null when this class is instantiated in Startup.Configure when we migrate the databas
			if (accessor?.HttpContext != null)
			{
				int tenantId = accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "tenant")?.Value.ToInt() ?? 0;
				Guid userId = accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user")?.Value.ToGuid() ?? Guid.Empty;
				this.SetTenantId(tenantId);
				this.SetUserId(userId);
			}
		}
	}
}

/*<Codenesium>
    <Hash>f4c34b1729b1c7c9737a65b92fe23b39</Hash>
</Codenesium>*/