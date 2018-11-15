using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiVersionInfoServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVersionInfoServerRequestModel()
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
    <Hash>3b4ea851a47152f01d7ffa12d17ee75a</Hash>
</Codenesium>*/