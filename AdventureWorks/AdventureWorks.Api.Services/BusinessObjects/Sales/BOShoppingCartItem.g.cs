using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOShoppingCartItem: AbstractBusinessObject
        {
                public BOShoppingCartItem() : base()
                {
                }

                public void SetProperties(int shoppingCartItemID,
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
                        this.ShoppingCartItemID = shoppingCartItemID;
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
    <Hash>590211c6fb0ca7ac3d6e0a64779531de</Hash>
</Codenesium>*/