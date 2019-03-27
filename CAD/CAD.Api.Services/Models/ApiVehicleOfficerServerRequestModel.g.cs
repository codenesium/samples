using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiVehicleOfficerServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVehicleOfficerServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int officerId,
			int vehicleId)
		{
			this.OfficerId = officerId;
			this.VehicleId = vehicleId;
		}

		[Required]
		[JsonProperty]
		public int OfficerId { get; private set; }

		[Required]
		[JsonProperty]
		public int VehicleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b1bcdf74aad899ed3a046f3f2dcacfee</Hash>
</Codenesium>*/