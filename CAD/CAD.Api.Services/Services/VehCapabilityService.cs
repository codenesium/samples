using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class VehCapabilityService : AbstractVehCapabilityService, IVehCapabilityService
	{
		public VehCapabilityService(
			ILogger<IVehCapabilityRepository> logger,
			IMediator mediator,
			IVehCapabilityRepository vehCapabilityRepository,
			IApiVehCapabilityServerRequestModelValidator vehCapabilityModelValidator,
			IDALVehCapabilityMapper dalVehCapabilityMapper,
			IDALVehicleCapabilitiesMapper dalVehicleCapabilitiesMapper)
			: base(logger,
			       mediator,
			       vehCapabilityRepository,
			       vehCapabilityModelValidator,
			       dalVehCapabilityMapper,
			       dalVehicleCapabilitiesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b951fab4facd6cff88ec22fafac2497b</Hash>
</Codenesium>*/