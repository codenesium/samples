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
    <Hash>012677b13ab2bcd27aac9bf31ff91d26</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/