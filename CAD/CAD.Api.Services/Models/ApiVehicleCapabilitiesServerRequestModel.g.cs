using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiVehicleCapabilitiesServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVehicleCapabilitiesServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int vehicleCapabilityId,
			int vehicleId)
		{
			this.VehicleCapabilityId = vehicleCapabilityId;
			this.VehicleId = vehicleId;
		}

		[Required]
		[JsonProperty]
		public int VehicleCapabilityId { get; private set; }

		[Required]
		[JsonProperty]
		public int VehicleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>626cb2ca611b791e8178e09c83e18793</Hash>
</Codenesium>*/