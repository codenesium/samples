using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class StoreService: AbstractStoreService, IStoreService
        {
                public StoreService(
                        ILogger<StoreRepository> logger,
                        IStoreRepository storeRepository,
                        IApiStoreRequestModelValidator storeModelValidator,
                        IBOLStoreMapper bolstoreMapper,
                        IDALStoreMapper dalstoreMapper)
                        : base(logger,
                               storeRepository,
                               storeModelValidator,
                               bolstoreMapper,
                               dalstoreMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>cc1bb2845d640a23022d5ae267f99ec4</Hash>
</Codenesium>*/