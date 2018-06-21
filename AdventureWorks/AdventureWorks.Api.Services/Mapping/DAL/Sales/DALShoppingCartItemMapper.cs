using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALShoppingCartItemMapper : DALAbstractShoppingCartItemMapper, IDALShoppingCartItemMapper
        {
                public DALShoppingCartItemMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3d0b870e1763202f4a15755928f50281</Hash>
</Codenesium>*/