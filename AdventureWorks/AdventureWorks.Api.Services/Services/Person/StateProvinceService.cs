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
        public class StateProvinceService: AbstractStateProvinceService, IStateProvinceService
        {
                public StateProvinceService(
                        ILogger<StateProvinceRepository> logger,
                        IStateProvinceRepository stateProvinceRepository,
                        IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
                        IBOLStateProvinceMapper bolstateProvinceMapper,
                        IDALStateProvinceMapper dalstateProvinceMapper
                        ,
                        IBOLAddressMapper bolAddressMapper,
                        IDALAddressMapper dalAddressMapper

                        )
                        : base(logger,
                               stateProvinceRepository,
                               stateProvinceModelValidator,
                               bolstateProvinceMapper,
                               dalstateProvinceMapper
                               ,
                               bolAddressMapper,
                               dalAddressMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>88ebfbcb24f7de0719204557374f8fb5</Hash>
</Codenesium>*/