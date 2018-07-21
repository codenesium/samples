using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductInventoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productID,
                        int bin,
                        short locationID,
                        DateTime modifiedDate,
                        short quantity,
                        Guid rowguid,
                        string shelf)
                {
                        this.ProductID = productID;
                        this.Bin = bin;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.Quantity = quantity;
                        this.Rowguid = rowguid;
                        this.Shelf = shelf;
                }

                [JsonProperty]
                public int Bin { get; private set; }

                [JsonProperty]
                public short LocationID { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public int ProductID { get; private set; }

                [JsonProperty]
                public short Quantity { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }

                [JsonProperty]
                public string Shelf { get; private set; }
        }
}

/*<Codenesium>
    <Hash>28987698ec1e8a85cbb2f1f33b7d80ec</Hash>
</Codenesium>*/