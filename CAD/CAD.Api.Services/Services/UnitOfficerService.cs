using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class UnitOfficerService : AbstractUnitOfficerService, IUnitOfficerService
	{
		public UnitOfficerService(
			ILogger<IUnitOfficerRepository> logger,
			IMediator mediator,
			IUnitOfficerRepository unitOfficerRepository,
			IApiUnitOfficerServerRequestModelValidator unitOfficerModelValidator,
			IDALUnitOfficerMapper dalUnitOfficerMapper)
			: base(logger,
			       mediator,
			       unitOfficerRepository,
			       unitOfficerModelValidator,
			       dalUnitOfficerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>94b10d27b2ce645d3df1410945f98cf6</Hash>
</Codenesium>*/