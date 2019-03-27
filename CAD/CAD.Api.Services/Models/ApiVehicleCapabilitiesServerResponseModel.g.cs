using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiVehicleCapabilitiesServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int vehicleCapabilityId,
			int vehicleId)
		{
			this.Id = id;
			this.VehicleCapabilityId = vehicleCapabilityId;
			this.VehicleId = vehicleId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int VehicleCapabilityId { get; private set; }

		[JsonProperty]
		public string VehicleCapabilityIdEntity { get; private set; } = RouteConstants.VehCapabilities;

		[JsonProperty]
		public ApiVehCapabilityServerResponseModel VehicleCapabilityIdNavigation { get; private set; }

		public void SetVehicleCapabilityIdNavigation(ApiVehCapabilityServerResponseModel value)
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
    <Hash>2c379cd98da4b5b26765bc7ab3a44e2b</Hash>
</Codenesium>*/