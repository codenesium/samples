using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiUnitOfficerClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int officerId,
			int unitId)
		{
			this.Id = id;
			this.OfficerId = officerId;
			this.UnitId = unitId;

			this.OfficerIdEntity = nameof(ApiResponse.Officers);

			this.UnitIdEntity = nameof(ApiResponse.Units);
		}

		[JsonProperty]
		public ApiOfficerClientResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerClientResponseModel value)
		{
			this.OfficerIdNavigation = value;
		}

		[JsonProperty]
		public ApiUnitClientResponseModel UnitIdNavigation { get; private set; }

		public void SetUnitIdNavigation(ApiUnitClientResponseModel value)
		{
			this.UnitIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; set; }

		[JsonProperty]
		public int UnitId { get; private set; }

		[JsonProperty]
		public string UnitIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>dfce15e370cdec60c3e5456a96635d87</Hash>
</Codenesium>*/