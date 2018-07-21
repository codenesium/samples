using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmailAddressRequestModel : AbstractApiRequestModel
        {
                public ApiEmailAddressRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string emailAddress1,
                        int emailAddressID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.EmailAddress1 = emailAddress1;
                        this.EmailAddressID = emailAddressID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public string EmailAddress1 { get; private set; }

                [Required]
                [JsonProperty]
                public int EmailAddressID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>44c8b4f75e89a931c43e9373ae8e4ddc</Hash>
</Codenesium>*/