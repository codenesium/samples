using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class OffCapabilityService : AbstractOffCapabilityService, IOffCapabilityService
	{
		public OffCapabilityService(
			ILogger<IOffCapabilityRepository> logger,
			IMediator mediator,
			IOffCapabilityRepository offCapabilityRepository,
			IApiOffCapabilityServerRequestModelValidator offCapabilityModelValidator,
			IDALOffCapabilityMapper dalOffCapabilityMapper,
			IDALOfficerCapabilitiesMapper dalOfficerCapabilitiesMapper)
			: base(logger,
			       mediator,
			       offCapabilityRepository,
			       offCapabilityModelValidator,
			       dalOffCapabilityMapper,
			       dalOfficerCapabilitiesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ececdf8e7dbe401f2c47ba7cdc113f0d</Hash>
</Codenesium>*/