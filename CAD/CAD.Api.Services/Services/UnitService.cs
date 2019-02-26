using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class UnitService : AbstractUnitService, IUnitService
	{
		public UnitService(
			ILogger<IUnitRepository> logger,
			IMediator mediator,
			IUnitRepository unitRepository,
			IApiUnitServerRequestModelValidator unitModelValidator,
			IDALUnitMapper dalUnitMapper)
			: base(logger,
			       mediator,
			       unitRepository,
			       unitModelValidator,
			       dalUnitMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>436564eb1c4796124616b4e5993741fe</Hash>
</Codenesium>*/