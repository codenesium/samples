using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiVehicleCapabilittyServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVehicleCapabilittyServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int vehicleCapabilityId)
		{
			this.VehicleCapabilityId = vehicleCapabilityId;
		}

		[Required]
		[JsonProperty]
		public int VehicleCapabilityId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1a87bac24c8b7d0bfc623679205a9cbb</Hash>
</Codenesium>*/