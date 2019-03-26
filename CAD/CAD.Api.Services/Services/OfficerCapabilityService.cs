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
			IDALOfficerCapabilityMapper dalOfficerCapabilityMapper)
			: base(logger,
			       mediator,
			       officerCapabilityRepository,
			       officerCapabilityModelValidator,
			       dalOfficerCapabilityMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b6249c1164c9a2df5a5748fca0c677f8</Hash>
</Codenesium>*/