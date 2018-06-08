using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALShoppingCartItemMapper: DALAbstractShoppingCartItemMapper, IDALShoppingCartItemMapper
        {
                public DALShoppingCartItemMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2f4909781872fea54e0e8e250212acca</Hash>
</Codenesium>*/