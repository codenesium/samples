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
		public DateTime? AppliedOn { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8c17cccf912833797534efc5daf7ce75</Hash>
</Codenesium>*/