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
                        IDALUnitMeasureMapper dalunitMeasureMapper
                        ,
                        IBOLBillOfMaterialsMapper bolBillOfMaterialsMapper,
                        IDALBillOfMaterialsMapper dalBillOfMaterialsMapper
                        ,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper

                        )
                        : base(logger,
                               unitMeasureRepository,
                               unitMeasureModelValidator,
                               bolunitMeasureMapper,
                               dalunitMeasureMapper
                               ,
                               bolBillOfMaterialsMapper,
                               dalBillOfMaterialsMapper
                               ,
                               bolProductMapper,
                               dalProductMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>22038b256aec6cf651b050d0831c3c43</Hash>
</Codenesium>*/