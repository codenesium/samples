using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiShoppingCartItemResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime dateCreated,
                        DateTime modifiedDate,
                        int productID,
                        int quantity,
                        string shoppingCartID,
                        int shoppingCartItemID)
                {
                        this.DateCreated = dateCreated;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ShoppingCartID = shoppingCartID;
                        this.ShoppingCartItemID = shoppingCartItemID;
                }

                public DateTime DateCreated { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public int Quantity { get; private set; }

                public string ShoppingCartID { get; private set; }

                public int ShoppingCartItemID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDateCreatedValue { get; set; } = true;

                public bool ShouldSerializeDateCreated()
                {
                        return this.ShouldSerializeDateCreatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeQuantityValue { get; set; } = true;

                public bool ShouldSerializeQuantity()
                {
                        return this.ShouldSerializeQuantityValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShoppingCartIDValue { get; set; } = true;

                public bool ShouldSerializeShoppingCartID()
                {
                        return this.ShouldSerializeShoppingCartIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShoppingCartItemIDValue { get; set; } = true;

                public bool ShouldSerializeShoppingCartItemID()
                {
                        return this.ShouldSerializeShoppingCartItemIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDateCreatedValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeQuantityValue = false;
                        this.ShouldSerializeShoppingCartIDValue = false;
                        this.ShouldSerializeShoppingCartItemIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a0653ab9118fab4708b340e6d72194e6</Hash>
</Codenesium>*/