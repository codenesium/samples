using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOAWBuildVersion: AbstractBusinessObject
	{
		public BOAWBuildVersion() : base()
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

		public string Database_Version { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int SystemInformationID { get; private set; }
		public DateTime VersionDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6b657f3252dbfb6bbdd61fa0fcce8479</Hash>
</Codenesium>*/