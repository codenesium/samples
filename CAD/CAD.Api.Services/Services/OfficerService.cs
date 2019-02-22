using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class OfficerService : AbstractOfficerService, IOfficerService
	{
		public OfficerService(
			ILogger<IOfficerRepository> logger,
			IMediator mediator,
			IOfficerRepository officerRepository,
			IApiOfficerServerRequestModelValidator officerModelValidator,
			IDALOfficerMapper dalOfficerMapper,
			IDALNoteMapper dalNoteMapper,
			IDALOfficerRefCapabilityMapper dalOfficerRefCapabilityMapper,
			IDALUnitOfficerMapper dalUnitOfficerMapper,
			IDALVehicleOfficerMapper dalVehicleOfficerMapper)
			: base(logger,
			       mediator,
			       officerRepository,
			       officerModelValidator,
			       dalOfficerMapper,
			       dalNoteMapper,
			       dalOfficerRefCapabilityMapper,
			       dalUnitOfficerMapper,
			       dalVehicleOfficerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>04166f713fe67100f3cbd5110e2031b5</Hash>
</Codenesium>*/