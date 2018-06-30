using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ApiKeyRepository : AbstractApiKeyRepository, IApiKeyRepository
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
    <Hash>7c7934653865d9c0b6d9eb5518167d1d</Hash>
</Codenesium>*/