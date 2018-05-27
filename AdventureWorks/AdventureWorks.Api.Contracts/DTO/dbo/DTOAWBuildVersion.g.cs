using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOAWBuildVersion: AbstractDTO
	{
		public DTOAWBuildVersion() : base()
		{}

		public void SetProperties(int systemInformationID,
		                          string database_Version,
		                          DateTime modifiedDate,
		                          DateTime versionDate)
		{
			this.Database_Version = database_Version;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SystemInformationID = systemInformationID.ToInt();
			this.VersionDate = versionDate.ToDateTime();
		}

		public string Database_Version { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int SystemInformationID { get; set; }
		public DateTime VersionDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>e63e698472e7dc24d44d6e27f2556e20</Hash>
</Codenesium>*/