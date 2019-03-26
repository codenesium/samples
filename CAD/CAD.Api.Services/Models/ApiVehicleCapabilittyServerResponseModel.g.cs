using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiVehicleCapabilittyServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int vehicleId,
			int vehicleCapabilityId)
		{
			this.VehicleId = vehicleId;
			this.VehicleCapabilityId = vehicleCapabilityId;
		}

		[JsonProperty]
		public int VehicleCapabilityId { get; private set; }

		[JsonProperty]
		public string VehicleCapabilityIdEntity { get; private set; } = RouteConstants.VehicleCapabilities;

		[JsonProperty]
		public ApiVehicleCapabilityServerResponseModel VehicleCapabilityIdNavigation { get; private set; }

		public void SetVehicleCapabilityIdNavigation(ApiVehicleCapabilityServerResponseModel value)
		{
			this.VehicleCapabilityIdNavigation = value;
		}

		[JsonProperty]
		public int VehicleId { get; private set; }

		[JsonProperty]
		public string VehicleIdEntity { get; private set; } = RouteConstants.Vehicles;

		[JsonProperty]
		public ApiVehicleServerResponseModel VehicleIdNavigation { get; private set; }

		public void SetVehicleIdNavigation(ApiVehicleServerResponseModel value)
		{
			this.VehicleIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>76bc22ba3d5f51cb7aa4190623415815</Hash>
</Codenesium>*/