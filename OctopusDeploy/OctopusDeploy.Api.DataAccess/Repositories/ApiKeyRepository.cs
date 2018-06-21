using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ApiKeyRepository : AbstractApiKeyRepository, IApiKeyRepository
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
    <Hash>9cf51910d785362a4d2c35a82b036e5f</Hash>
</Codenesium>*/