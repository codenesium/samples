using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiVehicleOfficerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVehicleOfficerClientRequestModel()
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

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public int VehicleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5ffc31150ca5ffbd943f46b758083eb3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/