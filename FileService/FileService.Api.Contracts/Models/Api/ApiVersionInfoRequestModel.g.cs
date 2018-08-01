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
    <Hash>b70c83dcc16e4d4630a4c60c8b638606</Hash>
</Codenesium>*/