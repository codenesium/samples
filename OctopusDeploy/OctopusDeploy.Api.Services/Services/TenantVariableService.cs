using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class TenantVariableService : AbstractTenantVariableService, ITenantVariableService
	{
		public TenantVariableService(
			ILogger<ITenantVariableRepository> logger,
			ITenantVariableRepository tenantVariableRepository,
			IApiTenantVariableRequestModelValidator tenantVariableModelValidator,
			IBOLTenantVariableMapper boltenantVariableMapper,
			IDALTenantVariableMapper daltenantVariableMapper
			)
			: base(logger,
			       tenantVariableRepository,
			       tenantVariableModelValidator,
			       boltenantVariableMapper,
			       daltenantVariableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>82cf3ccf6a1bbab9577cbae62e8f059a</Hash>
</Codenesium>*/