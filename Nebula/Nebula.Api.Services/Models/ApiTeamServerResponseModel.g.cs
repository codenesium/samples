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
		public string OrganizationIdEntity { get; private set; } = RouteConstants.Organizations;

		[JsonProperty]
		public ApiOrganizationServerResponseModel OrganizationIdNavigation { get; private set; }

		public void SetOrganizationIdNavigation(ApiOrganizationServerResponseModel value)
		{
			this.OrganizationIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>0b7e6d3780cf3ba8a7fe4ece16a4da98</Hash>
</Codenesium>*/