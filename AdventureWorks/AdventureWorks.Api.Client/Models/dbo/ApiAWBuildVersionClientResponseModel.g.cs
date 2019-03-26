using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiAWBuildVersionClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>4baa3a3adffada80148deb878e3d0ca5</Hash>
</Codenesium>*/