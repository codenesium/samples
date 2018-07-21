using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductDescriptionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productDescriptionID,
                        string description,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.ProductDescriptionID = productDescriptionID;
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public string Description { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public int ProductDescriptionID { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>89e7907685baa4fcc2b6faede3c55a92</Hash>
</Codenesium>*/