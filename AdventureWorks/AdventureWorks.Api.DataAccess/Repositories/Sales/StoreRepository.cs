using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>7c60db4774ac5d077f7a85cfdb652fc3</Hash>
</Codenesium>*/