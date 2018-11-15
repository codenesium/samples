using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiTeamClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int organizationId)
		{
			this.Id = id;
			this.Name = name;
			this.OrganizationId = organizationId;

			this.OrganizationIdEntity = nameof(ApiResponse.Organizations);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int OrganizationId { get; private set; }

		[JsonProperty]
		public string OrganizationIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>28e4f19162c5e942eebc2f751954d938</Hash>
</Codenesium>*/