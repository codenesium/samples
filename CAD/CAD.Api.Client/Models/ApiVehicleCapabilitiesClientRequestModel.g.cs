using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleCapabilitiesClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVehicleCapabilitiesClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int vehicleCapabilityId)
		{
			this.VehicleCapabilityId = vehicleCapabilityId;
		}

		[JsonProperty]
		public int VehicleCapabilityId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7926921c8d8e28424ae541926a12df15</Hash>
</Codenesium>*/