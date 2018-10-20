using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
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
		public DateTime? AppliedOn { get; private set; } = default(DateTime);

		[JsonProperty]
		public string Description { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>d26bf7886398aca795949f0764ad50b6</Hash>
</Codenesium>*/