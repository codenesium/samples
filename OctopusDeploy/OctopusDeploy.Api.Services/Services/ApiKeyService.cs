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
	public partial class ApiKeyService : AbstractApiKeyService, IApiKeyService
	{
		public ApiKeyService(
			ILogger<IApiKeyRepository> logger,
			IApiKeyRepository apiKeyRepository,
			IApiApiKeyRequestModelValidator apiKeyModelValidator,
			IBOLApiKeyMapper bolapiKeyMapper,
			IDALApiKeyMapper dalapiKeyMapper
			)
			: base(logger,
			       apiKeyRepository,
			       apiKeyModelValidator,
			       bolapiKeyMapper,
			       dalapiKeyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b47e596a2612db894183d21291c2353e</Hash>
</Codenesium>*/