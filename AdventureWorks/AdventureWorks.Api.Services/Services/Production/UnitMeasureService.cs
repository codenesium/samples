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
			IDALUnitMeasureMapper dalUnitMeasureMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       mediator,
			       unitMeasureRepository,
			       unitMeasureModelValidator,
			       dalUnitMeasureMapper,
			       dalBillOfMaterialMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>605a8b5a31987bd7503e75f0fa8cd89b</Hash>
</Codenesium>*/