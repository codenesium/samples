using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiAWBuildVersionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string database_Version,
                        DateTime modifiedDate,
                        int systemInformationID,
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

                [JsonIgnore]
                public bool ShouldSerializeDatabase_VersionValue { get; set; } = true;

                public bool ShouldSerializeDatabase_Version()
                {
                        return this.ShouldSerializeDatabase_VersionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSystemInformationIDValue { get; set; } = true;

                public bool ShouldSerializeSystemInformationID()
                {
                        return this.ShouldSerializeSystemInformationIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionDateValue { get; set; } = true;

                public bool ShouldSerializeVersionDate()
                {
                        return this.ShouldSerializeVersionDateValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDatabase_VersionValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeSystemInformationIDValue = false;
                        this.ShouldSerializeVersionDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>67b9e76303770362a46daddb88923771</Hash>
</Codenesium>*/