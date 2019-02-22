using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiVehicleRefCapabilityServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVehicleRefCapabilityServerRequestModel()
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
    <Hash>df89e55519efa079d12076c49f38f4b1</Hash>
</Codenesium>*/