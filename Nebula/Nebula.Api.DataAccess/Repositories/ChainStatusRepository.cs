using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class ChainStatusRepository: AbstractChainStatusRepository, IChainStatusRepository
        {
                public ChainStatusRepository(
                        ILogger<ChainStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f48f906a6c5a5473af40d4467691b3ea</Hash>
</Codenesium>*/