using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleRefCapabilityClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int vehicleCapabilityId,
			int vehicleId)
		{
			this.Id = id;
			this.VehicleCapabilityId = vehicleCapabilityId;
			this.VehicleId = vehicleId;

			this.VehicleCapabilityIdEntity = nameof(ApiResponse.VehicleCapabilities);

			this.VehicleIdEntity = nameof(ApiResponse.Vehicles);
		}

		[JsonProperty]
		public ApiVehicleCapabilityClientResponseModel VehicleCapabilityIdNavigation { get; private set; }

		public void SetVehicleCapabilityIdNavigation(ApiVehicleCapabilityClientResponseModel value)
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
    <Hash>7eb8cfe89268f81575f55d9d8a7c291b</Hash>
</Codenesium>*/