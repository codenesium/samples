using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class OfficerCapabilitiesService : AbstractOfficerCapabilitiesService, IOfficerCapabilitiesService
	{
		public OfficerCapabilitiesService(
			ILogger<IOfficerCapabilitiesRepository> logger,
			IMediator mediator,
			IOfficerCapabilitiesRepository officerCapabilitiesRepository,
			IApiOfficerCapabilitiesServerRequestModelValidator officerCapabilitiesModelValidator,
			IDALOfficerCapabilitiesMapper dalOfficerCapabilitiesMapper)
			: base(logger,
			       mediator,
			       officerCapabilitiesRepository,
			       officerCapabilitiesModelValidator,
			       dalOfficerCapabilitiesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>66aae701c2536ce1e4cfa9ecf3431b27</Hash>
</Codenesium>*/