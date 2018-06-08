using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOAWBuildVersion: AbstractBusinessObject
        {
                public BOAWBuildVersion() : base()
                {
                }

                public void SetProperties(int systemInformationID,
                                          string database_Version,
                                          DateTime modifiedDate,
                                          DateTime versionDate)
                {
                        this.Database_Version = database_Version;
                        this.ModifiedDate = modifiedDate;
                        this.SystemInformationID = systemInformationID;
                        this.VersionDate = versionDate;
                }

                public string Database_Version { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int SystemInformationID { get; private set; }

                public DateTime VersionDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>76e3dd6a6c79093770d82cc81de5308b</Hash>
</Codenesium>*/