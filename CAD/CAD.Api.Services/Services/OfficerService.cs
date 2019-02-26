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
			IDALOfficerCapabilitiesMapper dalOfficerCapabilitiesMapper)
			: base(logger,
			       mediator,
			       officerRepository,
			       officerModelValidator,
			       dalOfficerMapper,
			       dalNoteMapper,
			       dalOfficerCapabilitiesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d06d8e6d617ef291a3c0270cd6397b2e</Hash>
</Codenesium>*/