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
                        ILogger<ApiKeyRepository> logger,
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
    <Hash>e913d1d03b504a300ddf10df423e367a</Hash>
</Codenesium>*/