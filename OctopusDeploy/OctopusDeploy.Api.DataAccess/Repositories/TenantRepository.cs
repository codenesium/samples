using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
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
    <Hash>20a83daa3308b5e82f649561e7eaf69a</Hash>
</Codenesium>*/