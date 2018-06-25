using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class StoreService : AbstractStoreService, IStoreService
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
    <Hash>ef1824e48a60a0ab502ac6c68dcc90f8</Hash>
</Codenesium>*/