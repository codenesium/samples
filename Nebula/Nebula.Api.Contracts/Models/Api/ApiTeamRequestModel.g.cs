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

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int OrganizationId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>8fa6f5bdc4d112fe8e1433f7a7aefea9</Hash>
</Codenesium>*/