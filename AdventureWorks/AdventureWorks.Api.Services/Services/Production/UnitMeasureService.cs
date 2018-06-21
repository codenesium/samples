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
        public class UnitMeasureService : AbstractUnitMeasureService, IUnitMeasureService
        {
                public UnitMeasureService(
                        ILogger<IUnitMeasureRepository> logger,
                        IUnitMeasureRepository unitMeasureRepository,
                        IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
                        IBOLUnitMeasureMapper bolunitMeasureMapper,
                        IDALUnitMeasureMapper dalunitMeasureMapper,
                        IBOLBillOfMaterialsMapper bolBillOfMaterialsMapper,
                        IDALBillOfMaterialsMapper dalBillOfMaterialsMapper,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper
                        )
                        : base(logger,
                               unitMeasureRepository,
                               unitMeasureModelValidator,
                               bolunitMeasureMapper,
                               dalunitMeasureMapper,
                               bolBillOfMaterialsMapper,
                               dalBillOfMaterialsMapper,
                               bolProductMapper,
                               dalProductMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d4a3249188ecc2b478587de72e7284b8</Hash>
</Codenesium>*/