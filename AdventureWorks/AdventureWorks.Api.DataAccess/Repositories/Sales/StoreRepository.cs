using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class StoreRepository : AbstractStoreRepository, IStoreRepository
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
    <Hash>7707fc0a43777ef69ea47101136bb95a</Hash>
</Codenesium>*/