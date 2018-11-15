using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiAWBuildVersionServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>aa1cab60a90dd4e137156ed21d895a88</Hash>
</Codenesium>*/