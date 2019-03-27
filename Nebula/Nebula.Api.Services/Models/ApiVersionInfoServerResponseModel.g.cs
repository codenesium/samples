using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiVersionInfoServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public DateTime? AppliedOn { get; private set; }

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2e4a77171938513a83c9f2aea7b2b22d</Hash>
</Codenesium>*/