using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleCapabilittyClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVehicleCapabilittyClientRequestModel()
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
    <Hash>e62c325942eec5836633868ec985e52b</Hash>
</Codenesium>*/