using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
	public partial class ApiEfmigrationshistoryServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>59bd915170475b00989affe1fd3d964b</Hash>
</Codenesium>*/