using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiTeamServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTeamServerRequestModel()
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
		public int OrganizationId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>505dc27b936e47b7215f24be2f7234a5</Hash>
</Codenesium>*/