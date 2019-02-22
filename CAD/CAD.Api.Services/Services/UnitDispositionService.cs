using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class UnitDispositionService : AbstractUnitDispositionService, IUnitDispositionService
	{
		public UnitDispositionService(
			ILogger<IUnitDispositionRepository> logger,
			IMediator mediator,
			IUnitDispositionRepository unitDispositionRepository,
			IApiUnitDispositionServerRequestModelValidator unitDispositionModelValidator,
			IDALUnitDispositionMapper dalUnitDispositionMapper)
			: base(logger,
			       mediator,
			       unitDispositionRepository,
			       unitDispositionModelValidator,
			       dalUnitDispositionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>255f27ca7e9226d00ceac759bb449b25</Hash>
</Codenesium>*/