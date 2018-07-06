using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiShoppingCartItemResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int shoppingCartItemID,
                        DateTime dateCreated,
                        DateTime modifiedDate,
                        int productID,
                        int quantity,
                        string shoppingCartID)
                {
                        this.ShoppingCartItemID = shoppingCartItemID;
                        this.DateCreated = dateCreated;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ShoppingCartID = shoppingCartID;
                }

                public DateTime DateCreated { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public int Quantity { get; private set; }

                public string ShoppingCartID { get; private set; }

                public int ShoppingCartItemID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4585815c41de9553e9157d15c7f488db</Hash>
</Codenesium>*/