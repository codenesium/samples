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
			IDALVehicleCapabilitiesMapper dalVehicleCapabilitiesMapper,
			IDALVehicleOfficerMapper dalVehicleOfficerMapper)
			: base(logger,
			       mediator,
			       vehicleRepository,
			       vehicleModelValidator,
			       dalVehicleMapper,
			       dalVehicleCapabilitiesMapper,
			       dalVehicleOfficerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dc1aab26654e186b43cde9e83b9f9a42</Hash>
</Codenesium>*/