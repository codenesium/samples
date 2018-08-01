using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiVersionInfoResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e63e16fdaaafbcbe68be21ce397e61b3</Hash>
</Codenesium>*/