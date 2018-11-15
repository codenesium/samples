using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiVersionInfoClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVersionInfoClientRequestModel()
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
    <Hash>625a0ff1e4d85653d6b8b4e0057a1e2c</Hash>
</Codenesium>*/