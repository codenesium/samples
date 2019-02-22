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
			IDALUnitMapper dalUnitMapper,
			IDALUnitOfficerMapper dalUnitOfficerMapper,
			IDALCallAssignmentMapper dalCallAssignmentMapper)
			: base(logger,
			       mediator,
			       unitRepository,
			       unitModelValidator,
			       dalUnitMapper,
			       dalUnitOfficerMapper,
			       dalCallAssignmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7817eff6cffac883a83439d3d6a1fdfb</Hash>
</Codenesium>*/