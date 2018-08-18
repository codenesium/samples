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
    <Hash>bc72c3cf32e76aef32b374d14bf51bff</Hash>
</Codenesium>*/