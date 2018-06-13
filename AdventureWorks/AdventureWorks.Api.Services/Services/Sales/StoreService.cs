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
                        IDALStoreMapper dalstoreMapper
                        ,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper

                        )
                        : base(logger,
                               storeRepository,
                               storeModelValidator,
                               bolstoreMapper,
                               dalstoreMapper
                               ,
                               bolCustomerMapper,
                               dalCustomerMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>70f4369fb1545c44b08ac0c881ef1c8b</Hash>
</Codenesium>*/