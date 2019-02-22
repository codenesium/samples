using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiUnitOfficerServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int officerId,
			int unitId)
		{
			this.Id = id;
			this.OfficerId = officerId;
			this.UnitId = unitId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; private set; } = RouteConstants.Officers;

		[JsonProperty]
		public ApiOfficerServerResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerServerResponseModel value)
		{
			this.OfficerIdNavigation = value;
		}

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
    <Hash>4980bda26ff6effadd647986076e8478</Hash>
</Codenesium>*/