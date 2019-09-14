using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleCapabilitiesClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int vehicleCapabilityId,
			int vehicleId)
		{
			this.Id = id;
			this.VehicleCapabilityId = vehicleCapabilityId;
			this.VehicleId = vehicleId;

			this.VehicleCapabilityIdEntity = nameof(ApiResponse.VehCapabilities);

			this.VehicleIdEntity = nameof(ApiResponse.Vehicles);
		}

		[JsonProperty]
		public ApiVehCapabilityClientResponseModel VehicleCapabilityIdNavigation { get; private set; }

		public void SetVehicleCapabilityIdNavigation(ApiVehCapabilityClientResponseModel value)
		{
			this.VehicleCapabilityIdNavigation = value;
		}

		[JsonProperty]
		public ApiVehicleClientResponseModel VehicleIdNavigation { get; private set; }

		public void SetVehicleIdNavigation(ApiVehicleClientResponseModel value)
		{
			this.VehicleIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

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
    <Hash>26c775b05a519b80f416c45283e2f4f9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/