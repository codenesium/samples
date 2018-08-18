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
		public string Database_Version { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime VersionDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4df81710ee8976c9065315c9659ae911</Hash>
</Codenesium>*/