using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class ChainRepository : AbstractChainRepository, IChainRepository
        {
                public ChainRepository(
                        ILogger<ChainRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4ec64b8e21fc9c917b6571a76b1bb88e</Hash>
</Codenesium>*/