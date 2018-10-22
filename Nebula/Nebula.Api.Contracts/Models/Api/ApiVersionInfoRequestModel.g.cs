using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public DateTime? AppliedOn { get; private set; } = null;

		[JsonProperty]
		public string Description { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>984f7dca6217fc86710482545b7343fb</Hash>
</Codenesium>*/