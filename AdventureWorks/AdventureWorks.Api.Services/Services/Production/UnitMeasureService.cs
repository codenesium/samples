using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class UnitMeasureService : AbstractUnitMeasureService, IUnitMeasureService
	{
		public UnitMeasureService(
			ILogger<IUnitMeasureRepository> logger,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureServerRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper bolUnitMeasureMapper,
			IDALUnitMeasureMapper dalUnitMeasureMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       unitMeasureRepository,
			       unitMeasureModelValidator,
			       bolUnitMeasureMapper,
			       dalUnitMeasureMapper,
			       bolBillOfMaterialMapper,
			       dalBillOfMaterialMapper,
			       bolProductMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6c4d8328e13e5b76a62ca9294d0c926b</Hash>
</Codenesium>*/