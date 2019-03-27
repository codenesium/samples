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
			IDALCallAssignmentMapper dalCallAssignmentMapper,
			IDALUnitOfficerMapper dalUnitOfficerMapper)
			: base(logger,
			       mediator,
			       unitRepository,
			       unitModelValidator,
			       dalUnitMapper,
			       dalCallAssignmentMapper,
			       dalUnitOfficerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7c346be4b10b0b853ca6717a1ac78acf</Hash>
</Codenesium>*/