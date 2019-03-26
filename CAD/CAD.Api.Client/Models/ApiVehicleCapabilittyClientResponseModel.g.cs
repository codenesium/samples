using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleCapabilittyClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int vehicleId,
			int vehicleCapabilityId)
		{
			this.VehicleId = vehicleId;
			this.VehicleCapabilityId = vehicleCapabilityId;

			this.VehicleIdEntity = nameof(ApiResponse.Vehicles);
		}

		[JsonProperty]
		public ApiVehicleClientResponseModel VehicleIdNavigation { get; private set; }

		public void SetVehicleIdNavigation(ApiVehicleClientResponseModel value)
		{
			this.VehicleIdNavigation = value;
		}

		[JsonProperty]
		public int VehicleCapabilityId { get; private set; }

		[JsonProperty]
		public string VehicleCapabilityIdEntity { get; set; }

		[JsonProperty]
		public int VehicleId { get; private set; }

		[JsonProperty]
		public string VehicleIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>21dcc05540289a8ddc313e7c56bbc7b9</Hash>
</Codenesium>*/