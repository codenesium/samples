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
    <Hash>5b87e007e24e67bb9d08b42a3604578f</Hash>
</Codenesium>*/