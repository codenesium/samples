using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiVersionInfoClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			long version,
			DateTime? appliedOn,
			string description)
		{
			this.Version = version;
			this.AppliedOn = appliedOn;
			this.Description = description;
		}

		[JsonProperty]
		public DateTime? AppliedOn { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>284a54a46f3bcf2d9292a98723ba2f36</Hash>
</Codenesium>*/