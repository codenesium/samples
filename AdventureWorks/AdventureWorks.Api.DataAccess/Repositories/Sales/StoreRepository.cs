using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class StoreRepository : AbstractStoreRepository, IStoreRepository
        {
                public StoreRepository(
                        ILogger<StoreRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>254af5a5e37aca8471827c58c5a1d88e</Hash>
</Codenesium>*/