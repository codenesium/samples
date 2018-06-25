using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public partial class ChainRepository : AbstractChainRepository, IChainRepository
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
    <Hash>92dca753010fe051eae3c764e6de1502</Hash>
</Codenesium>*/