using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>aabe5f809ab81e927136cbb4ace7e08c</Hash>
</Codenesium>*/