using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class VehicleRefCapabilityService : AbstractVehicleRefCapabilityService, IVehicleRefCapabilityService
	{
		public VehicleRefCapabilityService(
			ILogger<IVehicleRefCapabilityRepository> logger,
			IMediator mediator,
			IVehicleRefCapabilityRepository vehicleRefCapabilityRepository,
			IApiVehicleRefCapabilityServerRequestModelValidator vehicleRefCapabilityModelValidator,
			IDALVehicleRefCapabilityMapper dalVehicleRefCapabilityMapper)
			: base(logger,
			       mediator,
			       vehicleRefCapabilityRepository,
			       vehicleRefCapabilityModelValidator,
			       dalVehicleRefCapabilityMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2ec4b5d054c035174f5e24bbf6e20615</Hash>
</Codenesium>*/