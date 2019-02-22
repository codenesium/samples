using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleRefCapabilityClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVehicleRefCapabilityClientRequestModel()
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

		[JsonProperty]
		public int VehicleCapabilityId { get; private set; }

		[JsonProperty]
		public int VehicleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b2db80269ee0046c3a093b92e75e24ac</Hash>
</Codenesium>*/