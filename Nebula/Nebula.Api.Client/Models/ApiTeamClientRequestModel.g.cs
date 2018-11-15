using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiTeamClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTeamClientRequestModel()
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
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int OrganizationId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ad7187c1b5e76205abe0d55b9fe4a10e</Hash>
</Codenesium>*/