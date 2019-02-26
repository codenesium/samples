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
    <Hash>cf617754086b5e19975e8bdab54a5722</Hash>
</Codenesium>*/