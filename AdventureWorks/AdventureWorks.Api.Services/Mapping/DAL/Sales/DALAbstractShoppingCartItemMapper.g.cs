using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractShoppingCartItemMapper
        {
                public virtual ShoppingCartItem MapBOToEF(
                        BOShoppingCartItem bo)
                {
                        ShoppingCartItem efShoppingCartItem = new ShoppingCartItem();
                        efShoppingCartItem.SetProperties(
                                bo.DateCreated,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.Quantity,
                                bo.ShoppingCartID,
                                bo.ShoppingCartItemID);
                        return efShoppingCartItem;
                }

                public virtual BOShoppingCartItem MapEFToBO(
                        ShoppingCartItem ef)
                {
                        var bo = new BOShoppingCartItem();

                        bo.SetProperties(
                                ef.ShoppingCartItemID,
                                ef.DateCreated,
                                ef.ModifiedDate,
                                ef.ProductID,
                                ef.Quantity,
                                ef.ShoppingCartID);
                        return bo;
                }

                public virtual List<BOShoppingCartItem> MapEFToBO(
                        List<ShoppingCartItem> records)
                {
                        List<BOShoppingCartItem> response = new List<BOShoppingCartItem>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2969350917481ab13f487c7f941b6ecb</Hash>
</Codenesium>*/