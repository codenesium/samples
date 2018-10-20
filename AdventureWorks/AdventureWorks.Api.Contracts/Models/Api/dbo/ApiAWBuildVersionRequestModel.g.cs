using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiAWBuildVersionRequestModel : AbstractApiRequestModel
	{
		public ApiAWBuildVersionRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime VersionDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>d0cd54d01d979fb7981f7cbb1532fa60</Hash>
</Codenesium>*/