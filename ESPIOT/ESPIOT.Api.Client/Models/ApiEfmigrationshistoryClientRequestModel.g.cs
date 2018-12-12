using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Client
{
	public partial class ApiEfmigrationshistoryClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEfmigrationshistoryClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string productVersion)
		{
			this.ProductVersion = productVersion;
		}

		[JsonProperty]
		public string ProductVersion { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>e2f7f8a408642881958392f52473ce3d</Hash>
</Codenesium>*/