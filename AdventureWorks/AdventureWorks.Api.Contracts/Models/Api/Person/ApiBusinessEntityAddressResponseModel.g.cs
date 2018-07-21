using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBusinessEntityAddressResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        int addressID,
                        int addressTypeID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.AddressID = addressID;
                        this.AddressTypeID = addressTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public int AddressID { get; private set; }

                [JsonProperty]
                public int AddressTypeID { get; private set; }

                [JsonProperty]
                public int BusinessEntityID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a603c089f5c2b86ef812b867c10f4266</Hash>
</Codenesium>*/