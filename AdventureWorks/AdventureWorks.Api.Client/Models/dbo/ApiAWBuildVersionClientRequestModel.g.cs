using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiAWBuildVersionClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiAWBuildVersionClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string database_Version,
			DateTime modifiedDate,
			DateTime versionDate)
		{
			this.Database_Version = database_Version;
			this.ModifiedDate = modifiedDate;
			this.VersionDate = versionDate;
		}

		[JsonProperty]
		public string Database_Version { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime VersionDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>bb01afe02f39c6aa5ffa441f902c037e</Hash>
</Codenesium>*/