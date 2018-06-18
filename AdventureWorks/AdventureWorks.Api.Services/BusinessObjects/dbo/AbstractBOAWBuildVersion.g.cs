using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOAWBuildVersion: AbstractBusinessObject
        {
                public AbstractBOAWBuildVersion() : base()
                {
                }

                public virtual void SetProperties(int systemInformationID,
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
    <Hash>db7470a1c767c5518fa1d6c81888148c</Hash>
</Codenesium>*/