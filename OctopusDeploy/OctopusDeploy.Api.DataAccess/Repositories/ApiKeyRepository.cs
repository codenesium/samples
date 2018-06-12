using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ApiKeyRepository: AbstractApiKeyRepository, IApiKeyRepository
        {
                public ApiKeyRepository(
                        ILogger<ApiKeyRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>64cb4a37c942692c3167029e0dead507</Hash>
</Codenesium>*/