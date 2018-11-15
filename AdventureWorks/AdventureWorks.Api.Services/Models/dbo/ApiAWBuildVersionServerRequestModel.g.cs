using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiAWBuildVersionServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiAWBuildVersionServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Database_Version { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public DateTime VersionDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>c4e77eb2ae66458daa51f39b1bf57050</Hash>
</Codenesium>*/