using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiCallAssignmentServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int callId,
			int unitId)
		{
			this.Id = id;
			this.CallId = callId;
			this.UnitId = unitId;
		}

		[JsonProperty]
		public int CallId { get; private set; }

		[JsonProperty]
		public string CallIdEntity { get; private set; } = RouteConstants.Calls;

		[JsonProperty]
		public ApiCallServerResponseModel CallIdNavigation { get; private set; }

		public void SetCallIdNavigation(ApiCallServerResponseModel value)
		{
			this.CallIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int UnitId { get; private set; }

		[JsonProperty]
		public string UnitIdEntity { get; private set; } = RouteConstants.Units;

		[JsonProperty]
		public ApiUnitServerResponseModel UnitIdNavigation { get; private set; }

		public void SetUnitIdNavigation(ApiUnitServerResponseModel value)
		{
			this.UnitIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>45278a60e58e52e9ec39167c7dccb667</Hash>
</Codenesium>*/