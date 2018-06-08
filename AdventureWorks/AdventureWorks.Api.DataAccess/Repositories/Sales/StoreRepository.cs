using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class StoreRepository: AbstractStoreRepository, IStoreRepository
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
    <Hash>5e512680a7c8042c8716a07c510c9b0c</Hash>
</Codenesium>*/