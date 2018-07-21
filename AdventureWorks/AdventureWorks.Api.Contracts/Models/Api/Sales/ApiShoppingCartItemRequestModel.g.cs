using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiShoppingCartItemRequestModel : AbstractApiRequestModel
        {
                public ApiShoppingCartItemRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime dateCreated,
                        DateTime modifiedDate,
                        int productID,
                        int quantity,
                        string shoppingCartID)
                {
                        this.DateCreated = dateCreated;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ShoppingCartID = shoppingCartID;
                }

                [Required]
                [JsonProperty]
                public DateTime DateCreated { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public int ProductID { get; private set; }

                [Required]
                [JsonProperty]
                public int Quantity { get; private set; }

                [Required]
                [JsonProperty]
                public string ShoppingCartID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bc6ad45390557054a5521b1dfd55f06a</Hash>
</Codenesium>*/