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
			IDALVehicleCapabilittyMapper dalVehicleCapabilittyMapper)
			: base(logger,
			       mediator,
			       vehicleRepository,
			       vehicleModelValidator,
			       dalVehicleMapper,
			       dalVehicleCapabilittyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dedc436ec826f12b5f2316cf1fbaf182</Hash>
</Codenesium>*/