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
	public partial class TenantVariableRepository : AbstractTenantVariableRepository, ITenantVariableRepository
	{
		public TenantVariableRepository(
			ILogger<TenantVariableRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1b07f17a97c289c965379b954c9d0b7c</Hash>
</Codenesium>*/