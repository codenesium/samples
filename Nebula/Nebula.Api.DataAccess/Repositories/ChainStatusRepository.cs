using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class ChainStatusRepository : AbstractChainStatusRepository, IChainStatusRepository
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
    <Hash>bbaabca1477e55ab2f74844fb53d1fa3</Hash>
</Codenesium>*/