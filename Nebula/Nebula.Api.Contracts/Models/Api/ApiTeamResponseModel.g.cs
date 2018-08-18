using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiTeamResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int OrganizationId { get; private set; }

		[JsonProperty]
		public string OrganizationIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>87b93340b656e2e7d88ef2b452f0dceb</Hash>
</Codenesium>*/