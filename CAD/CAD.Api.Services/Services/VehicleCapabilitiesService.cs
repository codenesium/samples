using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class VehicleCapabilitiesService : AbstractVehicleCapabilitiesService, IVehicleCapabilitiesService
	{
		public VehicleCapabilitiesService(
			ILogger<IVehicleCapabilitiesRepository> logger,
			IMediator mediator,
			IVehicleCapabilitiesRepository vehicleCapabilitiesRepository,
			IApiVehicleCapabilitiesServerRequestModelValidator vehicleCapabilitiesModelValidator,
			IDALVehicleCapabilitiesMapper dalVehicleCapabilitiesMapper)
			: base(logger,
			       mediator,
			       vehicleCapabilitiesRepository,
			       vehicleCapabilitiesModelValidator,
			       dalVehicleCapabilitiesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e20dbcf68613d155b8e798bb5de9ab12</Hash>
</Codenesium>*/