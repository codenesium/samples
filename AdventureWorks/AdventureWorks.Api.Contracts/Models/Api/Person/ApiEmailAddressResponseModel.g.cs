using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmailAddressResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        string emailAddress1,
                        int emailAddressID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.EmailAddress1 = emailAddress1;
                        this.EmailAddressID = emailAddressID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public int BusinessEntityID { get; private set; }

                [Required]
                [JsonProperty]
                public string EmailAddress1 { get; private set; }

                [JsonProperty]
                public int EmailAddressID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>033b1d19e7d566085c5c56ae65538f49</Hash>
</Codenesium>*/