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
                        IDALStateProvinceMapper dalstateProvinceMapper)
                        : base(logger,
                               stateProvinceRepository,
                               stateProvinceModelValidator,
                               bolstateProvinceMapper,
                               dalstateProvinceMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ec28982512542d7f6bc8852dd536fe4c</Hash>
</Codenesium>*/