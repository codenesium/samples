using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class UnitMeasureService : AbstractUnitMeasureService, IUnitMeasureService
	{
		public UnitMeasureService(
			ILogger<IUnitMeasureRepository> logger,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper bolunitMeasureMapper,
			IDALUnitMeasureMapper dalunitMeasureMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper
			)
			: base(logger,
			       unitMeasureRepository,
			       unitMeasureModelValidator,
			       bolunitMeasureMapper,
			       dalunitMeasureMapper,
			       bolBillOfMaterialMapper,
			       dalBillOfMaterialMapper,
			       bolProductMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>acbea2c24412e94e320c60cde300fa37</Hash>
</Codenesium>*/