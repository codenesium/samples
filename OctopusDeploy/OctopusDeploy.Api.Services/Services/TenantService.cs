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
	public partial class TenantService : AbstractTenantService, ITenantService
	{
		public TenantService(
			ILogger<ITenantRepository> logger,
			ITenantRepository tenantRepository,
			IApiTenantRequestModelValidator tenantModelValidator,
			IBOLTenantMapper boltenantMapper,
			IDALTenantMapper daltenantMapper
			)
			: base(logger,
			       tenantRepository,
			       tenantModelValidator,
			       boltenantMapper,
			       daltenantMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f645ed0ae822ae976b45b3b633b77765</Hash>
</Codenesium>*/