using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiTeamServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int organizationId)
		{
			this.Id = id;
			this.Name = name;
			this.OrganizationId = organizationId;
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
    <Hash>e557123cf6279d66e0e1992847ff42a6</Hash>
</Codenesium>*/