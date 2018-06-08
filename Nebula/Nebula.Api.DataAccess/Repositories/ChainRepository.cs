using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class ChainRepository: AbstractChainRepository, IChainRepository
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
    <Hash>b1dd8b74df985397e312c953771fdf21</Hash>
</Codenesium>*/