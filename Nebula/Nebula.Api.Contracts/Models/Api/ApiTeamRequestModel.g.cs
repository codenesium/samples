using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiTeamRequestModel : AbstractApiRequestModel
	{
		public ApiTeamRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			int organizationId)
		{
			this.Name = name;
			this.OrganizationId = organizationId;
		}

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int OrganizationId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4404e91a3e063c92cff26025b8de2446</Hash>
</Codenesium>*/