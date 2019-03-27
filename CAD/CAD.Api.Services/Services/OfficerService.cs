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
			IDALOfficerCapabilitiesMapper dalOfficerCapabilitiesMapper,
			IDALUnitOfficerMapper dalUnitOfficerMapper,
			IDALVehicleOfficerMapper dalVehicleOfficerMapper)
			: base(logger,
			       mediator,
			       officerRepository,
			       officerModelValidator,
			       dalOfficerMapper,
			       dalNoteMapper,
			       dalOfficerCapabilitiesMapper,
			       dalUnitOfficerMapper,
			       dalVehicleOfficerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0967def9083d82ae21935484930c85db</Hash>
</Codenesium>*/