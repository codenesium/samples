using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public partial class ChainStatusRepository : AbstractChainStatusRepository, IChainStatusRepository
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
    <Hash>c667b9580a2088e91fb9440b9b30e48b</Hash>
</Codenesium>*/