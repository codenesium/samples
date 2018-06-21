using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class StoreService : AbstractStoreService, IStoreService
        {
                public StoreService(
                        ILogger<IStoreRepository> logger,
                        IStoreRepository storeRepository,
                        IApiStoreRequestModelValidator storeModelValidator,
                        IBOLStoreMapper bolstoreMapper,
                        IDALStoreMapper dalstoreMapper,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper
                        )
                        : base(logger,
                               storeRepository,
                               storeModelValidator,
                               bolstoreMapper,
                               dalstoreMapper,
                               bolCustomerMapper,
                               dalCustomerMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c4f01fd5a1bc27639f17dc225f2c6eb8</Hash>
</Codenesium>*/