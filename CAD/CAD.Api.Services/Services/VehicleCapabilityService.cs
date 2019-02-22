using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class VehicleCapabilityService : AbstractVehicleCapabilityService, IVehicleCapabilityService
	{
		public VehicleCapabilityService(
			ILogger<IVehicleCapabilityRepository> logger,
			IMediator mediator,
			IVehicleCapabilityRepository vehicleCapabilityRepository,
			IApiVehicleCapabilityServerRequestModelValidator vehicleCapabilityModelValidator,
			IDALVehicleCapabilityMapper dalVehicleCapabilityMapper,
			IDALVehicleRefCapabilityMapper dalVehicleRefCapabilityMapper)
			: base(logger,
			       mediator,
			       vehicleCapabilityRepository,
			       vehicleCapabilityModelValidator,
			       dalVehicleCapabilityMapper,
			       dalVehicleRefCapabilityMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>61d9c7b0e1afba9851c1665e3124573f</Hash>
</Codenesium>*/