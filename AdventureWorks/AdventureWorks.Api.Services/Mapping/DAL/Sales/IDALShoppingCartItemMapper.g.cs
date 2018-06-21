using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALShoppingCartItemMapper
        {
                ShoppingCartItem MapBOToEF(
                        BOShoppingCartItem bo);

                BOShoppingCartItem MapEFToBO(
                        ShoppingCartItem efShoppingCartItem);

                List<BOShoppingCartItem> MapEFToBO(
                        List<ShoppingCartItem> records);
        }
}

/*<Codenesium>
    <Hash>920659d79e5b632fdf45e7468b8c6397</Hash>
</Codenesium>*/