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
    <Hash>6c497eab89ee9b80aa7590504b24c8b9</Hash>
</Codenesium>*/