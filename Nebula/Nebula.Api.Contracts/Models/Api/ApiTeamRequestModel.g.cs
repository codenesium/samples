using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int OrganizationId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>843ed0081c67826ed11c96e3e655151d</Hash>
</Codenesium>*/