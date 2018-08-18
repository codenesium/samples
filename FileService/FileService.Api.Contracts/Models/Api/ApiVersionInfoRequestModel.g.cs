using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiVersionInfoRequestModel : AbstractApiRequestModel
	{
		public ApiVersionInfoRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? appliedOn,
			string description)
		{
			this.AppliedOn = appliedOn;
			this.Description = description;
		}

		[JsonProperty]
		public DateTime? AppliedOn { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }
	}
}

/*<Codenesium>
    <Hash>89af11910881ed1c1518172d403d118f</Hash>
</Codenesium>*/