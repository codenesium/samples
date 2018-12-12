using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
	public partial class ApiEfmigrationshistoryServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEfmigrationshistoryServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string productVersion)
		{
			this.ProductVersion = productVersion;
		}

		[Required]
		[JsonProperty]
		public string ProductVersion { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>e55ba70aa7d0f2e31123badc836992e8</Hash>
</Codenesium>*/