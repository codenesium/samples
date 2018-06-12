using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class MutexRepository: AbstractMutexRepository, IMutexRepository
        {
                public MutexRepository(
                        ILogger<MutexRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f9b535a53b956b46f229aa94f8bc6672</Hash>
</Codenesium>*/