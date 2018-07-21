using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPasswordResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        string passwordHash,
                        string passwordSalt,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PasswordHash = passwordHash;
                        this.PasswordSalt = passwordSalt;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public int BusinessEntityID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string PasswordHash { get; private set; }

                [JsonProperty]
                public string PasswordSalt { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>918a767d607c351c29a9438d343cbbdd</Hash>
</Codenesium>*/