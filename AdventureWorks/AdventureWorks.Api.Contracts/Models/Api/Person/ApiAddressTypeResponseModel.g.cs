using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiAddressTypeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int addressTypeID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.AddressTypeID = addressTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public int AddressTypeID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3f5f6431eef4cd9e6e162a1afccf8b03</Hash>
</Codenesium>*/