using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class UnitMeasureService : AbstractUnitMeasureService, IUnitMeasureService
	{
		public UnitMeasureService(
			ILogger<IUnitMeasureRepository> logger,
			IMediator mediator,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureServerRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper bolUnitMeasureMapper,
			IDALUnitMeasureMapper dalUnitMeasureMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       mediator,
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
    <Hash>5be951c4804f00ced4599570b5ca6937</Hash>
</Codenesium>*/