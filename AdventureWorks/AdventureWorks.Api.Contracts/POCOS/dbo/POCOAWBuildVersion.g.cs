using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOAWBuildVersion
	{
		public POCOAWBuildVersion()
		{}

		public POCOAWBuildVersion(
			int systemInformationID,
			string database_Version,
			DateTime versionDate,
			DateTime modifiedDate)
		{
			this.SystemInformationID = systemInformationID;
			this.Database_Version = database_Version;
			this.VersionDate = versionDate.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int SystemInformationID { get; set; }
		public string Database_Version { get; set; }
		public DateTime VersionDate { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeSystemInformationIDValue { get; set; } = true;

		public bool ShouldSerializeSystemInformationID()
		{
			return this.ShouldSerializeSystemInformationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDatabase_VersionValue { get; set; } = true;

		public bool ShouldSerializeDatabase_Version()
		{
			return this.ShouldSerializeDatabase_VersionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeVersionDateValue { get; set; } = true;

		public bool ShouldSerializeVersionDate()
		{
			return this.ShouldSerializeVersionDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeSystemInformationIDValue = false;
			this.ShouldSerializeDatabase_VersionValue = false;
			this.ShouldSerializeVersionDateValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>15f2807966ac5abbf8b50d246a4f5ed9</Hash>
</Codenesium>*/