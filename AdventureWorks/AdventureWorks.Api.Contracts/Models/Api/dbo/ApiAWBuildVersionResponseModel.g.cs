using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiAWBuildVersionResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int systemInformationID,
			string database_Version,
			DateTime modifiedDate,
			DateTime versionDate)
		{
			this.SystemInformationID = systemInformationID;
			this.Database_Version = database_Version;
			this.ModifiedDate = modifiedDate;
			this.VersionDate = versionDate;
		}

		[JsonProperty]
		public string Database_Version { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int SystemInformationID { get; private set; }

		[JsonProperty]
		public DateTime VersionDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>805ca40f1a9aa4b4144afe247fcaa23c</Hash>
</Codenesium>*/