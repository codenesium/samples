using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiAWBuildVersionRequestModel: AbstractApiRequestModel
        {
                public ApiAWBuildVersionRequestModel() : base()
                {
                }

                public void SetProperties(
                        string database_Version,
                        DateTime modifiedDate,
                        DateTime versionDate)
                {
                        this.Database_Version = database_Version;
                        this.ModifiedDate = modifiedDate;
                        this.VersionDate = versionDate;
                }

                private string database_Version;

                [Required]
                public string Database_Version
                {
                        get
                        {
                                return this.database_Version;
                        }

                        set
                        {
                                this.database_Version = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private DateTime versionDate;

                [Required]
                public DateTime VersionDate
                {
                        get
                        {
                                return this.versionDate;
                        }

                        set
                        {
                                this.versionDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8b1b8ed2f10e31eb949de94c4346a3ec</Hash>
</Codenesium>*/