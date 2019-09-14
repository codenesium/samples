using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiCallAssignmentClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int callId,
			int unitId)
		{
			this.Id = id;
			this.CallId = callId;
			this.UnitId = unitId;

			this.CallIdEntity = nameof(ApiResponse.Calls);

			this.UnitIdEntity = nameof(ApiResponse.Units);
		}

		[JsonProperty]
		public ApiCallClientResponseModel CallIdNavigation { get; private set; }

		public void SetCallIdNavigation(ApiCallClientResponseModel value)
		{
			this.CallIdNavigation = value;
		}

		[JsonProperty]
		public ApiUnitClientResponseModel UnitIdNavigation { get; private set; }

		public void SetUnitIdNavigation(ApiUnitClientResponseModel value)
		{
			this.UnitIdNavigation = value;
		}

		[JsonProperty]
		public int CallId { get; private set; }

		[JsonProperty]
		public string CallIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int UnitId { get; private set; }

		[JsonProperty]
		public string UnitIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>ed816c52bc85712f54cbcda3a651fc8c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/