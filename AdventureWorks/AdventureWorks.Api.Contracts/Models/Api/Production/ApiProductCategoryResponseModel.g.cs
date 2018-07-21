using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductCategoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productCategoryID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.ProductCategoryID = productCategoryID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int ProductCategoryID { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b972ed7d39f0dfe77ee8d46f916810cb</Hash>
</Codenesium>*/