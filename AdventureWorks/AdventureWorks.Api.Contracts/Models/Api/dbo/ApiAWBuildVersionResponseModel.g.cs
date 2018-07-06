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

                public string Database_Version { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int SystemInformationID { get; private set; }

                public DateTime VersionDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a73b681abf2a269ebdd1772b35563f54</Hash>
</Codenesium>*/