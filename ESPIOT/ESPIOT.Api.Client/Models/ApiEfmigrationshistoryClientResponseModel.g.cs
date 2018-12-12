using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Client
{
	public partial class ApiEfmigrationshistoryClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			string migrationId,
			string productVersion)
		{
			this.MigrationId = migrationId;
			this.ProductVersion = productVersion;
		}

		[JsonProperty]
		public string MigrationId { get; private set; }

		[JsonProperty]
		public string ProductVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>24373df27e0529997ad4786e5d39a077</Hash>
</Codenesium>*/