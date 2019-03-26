using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class VehicleCapabilittyService : AbstractVehicleCapabilittyService, IVehicleCapabilittyService
	{
		public VehicleCapabilittyService(
			ILogger<IVehicleCapabilittyRepository> logger,
			IMediator mediator,
			IVehicleCapabilittyRepository vehicleCapabilittyRepository,
			IApiVehicleCapabilittyServerRequestModelValidator vehicleCapabilittyModelValidator,
			IDALVehicleCapabilittyMapper dalVehicleCapabilittyMapper)
			: base(logger,
			       mediator,
			       vehicleCapabilittyRepository,
			       vehicleCapabilittyModelValidator,
			       dalVehicleCapabilittyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6f74d8d75aab0482761e8b1cf47f57f7</Hash>
</Codenesium>*/