using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>6abec8b8ed1f1b3227b83fefa3b3c58c</Hash>
</Codenesium>*/