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
			IDALVehicleOfficerMapper dalVehicleOfficerMapper,
			IDALVehicleRefCapabilityMapper dalVehicleRefCapabilityMapper)
			: base(logger,
			       mediator,
			       vehicleRepository,
			       vehicleModelValidator,
			       dalVehicleMapper,
			       dalVehicleOfficerMapper,
			       dalVehicleRefCapabilityMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d2ce27eee6fbf87e6221eb2c41037eb8</Hash>
</Codenesium>*/