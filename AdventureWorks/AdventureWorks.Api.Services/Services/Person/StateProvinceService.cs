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
        public class StateProvinceService : AbstractStateProvinceService, IStateProvinceService
        {
                public StateProvinceService(
                        ILogger<IStateProvinceRepository> logger,
                        IStateProvinceRepository stateProvinceRepository,
                        IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
                        IBOLStateProvinceMapper bolstateProvinceMapper,
                        IDALStateProvinceMapper dalstateProvinceMapper,
                        IBOLAddressMapper bolAddressMapper,
                        IDALAddressMapper dalAddressMapper
                        )
                        : base(logger,
                               stateProvinceRepository,
                               stateProvinceModelValidator,
                               bolstateProvinceMapper,
                               dalstateProvinceMapper,
                               bolAddressMapper,
                               dalAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e832ec1f208ad3273a60ad4bbc79be04</Hash>
</Codenesium>*/