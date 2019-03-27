using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class VehicleOfficerService : AbstractVehicleOfficerService, IVehicleOfficerService
	{
		public VehicleOfficerService(
			ILogger<IVehicleOfficerRepository> logger,
			IMediator mediator,
			IVehicleOfficerRepository vehicleOfficerRepository,
			IApiVehicleOfficerServerRequestModelValidator vehicleOfficerModelValidator,
			IDALVehicleOfficerMapper dalVehicleOfficerMapper)
			: base(logger,
			       mediator,
			       vehicleOfficerRepository,
			       vehicleOfficerModelValidator,
			       dalVehicleOfficerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>96b7f90f1bdcd59320476e125654f52f</Hash>
</Codenesium>*/