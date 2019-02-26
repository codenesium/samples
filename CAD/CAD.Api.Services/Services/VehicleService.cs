using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class VehicleService : AbstractVehicleService, IVehicleService
	{
		public VehicleService(
			ILogger<IVehicleRepository> logger,
			IMediator mediator,
			IVehicleRepository vehicleRepository,
			IApiVehicleServerRequestModelValidator vehicleModelValidator,
			IDALVehicleMapper dalVehicleMapper,
			IDALVehicleCapabilitiesMapper dalVehicleCapabilitiesMapper)
			: base(logger,
			       mediator,
			       vehicleRepository,
			       vehicleModelValidator,
			       dalVehicleMapper,
			       dalVehicleCapabilitiesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>13f8c02a20dc1b87cc9be8ddfc216bd1</Hash>
</Codenesium>*/