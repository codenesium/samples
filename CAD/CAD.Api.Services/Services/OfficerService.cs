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
			IDALOfficerCapabilityMapper dalOfficerCapabilityMapper)
			: base(logger,
			       mediator,
			       officerRepository,
			       officerModelValidator,
			       dalOfficerMapper,
			       dalNoteMapper,
			       dalOfficerCapabilityMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d9655658425fa8c111e299713b134fca</Hash>
</Codenesium>*/