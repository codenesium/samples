using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class OfficerRefCapabilityService : AbstractOfficerRefCapabilityService, IOfficerRefCapabilityService
	{
		public OfficerRefCapabilityService(
			ILogger<IOfficerRefCapabilityRepository> logger,
			IMediator mediator,
			IOfficerRefCapabilityRepository officerRefCapabilityRepository,
			IApiOfficerRefCapabilityServerRequestModelValidator officerRefCapabilityModelValidator,
			IDALOfficerRefCapabilityMapper dalOfficerRefCapabilityMapper)
			: base(logger,
			       mediator,
			       officerRefCapabilityRepository,
			       officerRefCapabilityModelValidator,
			       dalOfficerRefCapabilityMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0162cc7bd9b7c60d394a6c191bd13b72</Hash>
</Codenesium>*/