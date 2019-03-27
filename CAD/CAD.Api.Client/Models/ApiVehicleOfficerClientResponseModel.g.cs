using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleOfficerClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int officerId,
			int vehicleId)
		{
			this.Id = id;
			this.OfficerId = officerId;
			this.VehicleId = vehicleId;

			this.OfficerIdEntity = nameof(ApiResponse.Officers);

			this.VehicleIdEntity = nameof(ApiResponse.Vehicles);
		}

		[JsonProperty]
		public ApiOfficerClientResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerClientResponseModel value)
		{
			this.OfficerIdNavigation = value;
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
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; set; }

		[JsonProperty]
		public int VehicleId { get; private set; }

		[JsonProperty]
		public string VehicleIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>1b28006cd73ad7b4176ce6183d6002f7</Hash>
</Codenesium>*/