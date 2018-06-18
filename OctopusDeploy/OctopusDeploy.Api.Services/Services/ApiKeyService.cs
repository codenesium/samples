using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiKeyService: AbstractApiKeyService, IApiKeyService
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
                               dalapiKeyMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>16b5347829abacb39803ac6fbbbc78f4</Hash>
</Codenesium>*/