using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiVehicleOfficerServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int officerId,
			int vehicleId)
		{
			this.Id = id;
			this.OfficerId = officerId;
			this.VehicleId = vehicleId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; private set; } = RouteConstants.Officers;

		[JsonProperty]
		public ApiOfficerServerResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerServerResponseModel value)
		{
			this.OfficerIdNavigation = value;
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
    <Hash>297ccfdc62051fdef115376eef0505c9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/