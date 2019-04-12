using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class TenantRepository : AbstractTenantRepository, ITenantRepository
	{
		public TenantRepository(
			ILogger<TenantRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d1f53f8ba634d640fa952f48575bc9ae</Hash>
</Codenesium>*/