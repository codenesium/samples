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
        public class UnitMeasureService: AbstractUnitMeasureService, IUnitMeasureService
        {
                public UnitMeasureService(
                        ILogger<UnitMeasureRepository> logger,
                        IUnitMeasureRepository unitMeasureRepository,
                        IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
                        IBOLUnitMeasureMapper bolunitMeasureMapper,
                        IDALUnitMeasureMapper dalunitMeasureMapper)
                        : base(logger,
                               unitMeasureRepository,
                               unitMeasureModelValidator,
                               bolunitMeasureMapper,
                               dalunitMeasureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>22b6f8d792e1436d00420abaab5a8d72</Hash>
</Codenesium>*/