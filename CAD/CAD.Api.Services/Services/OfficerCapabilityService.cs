using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class OfficerCapabilityService : AbstractOfficerCapabilityService, IOfficerCapabilityService
	{
		public OfficerCapabilityService(
			ILogger<IOfficerCapabilityRepository> logger,
			IMediator mediator,
			IOfficerCapabilityRepository officerCapabilityRepository,
			IApiOfficerCapabilityServerRequestModelValidator officerCapabilityModelValidator,
			IDALOfficerCapabilityMapper dalOfficerCapabilityMapper,
			IDALOfficerRefCapabilityMapper dalOfficerRefCapabilityMapper)
			: base(logger,
			       mediator,
			       officerCapabilityRepository,
			       officerCapabilityModelValidator,
			       dalOfficerCapabilityMapper,
			       dalOfficerRefCapabilityMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>04c882e9bf664a4bd8966fbc3a0b6514</Hash>
</Codenesium>*/