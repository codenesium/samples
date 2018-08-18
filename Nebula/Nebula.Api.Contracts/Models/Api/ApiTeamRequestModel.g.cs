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
    <Hash>c5307e008f2f87a42b02bc31eea45dc9</Hash>
</Codenesium>*/