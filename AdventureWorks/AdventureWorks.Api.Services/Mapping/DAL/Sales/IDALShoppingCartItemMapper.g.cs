using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>f03ca7a9962c5fc12b885ba3ad8a9568</Hash>
</Codenesium>*/