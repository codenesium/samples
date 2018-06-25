using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALShoppingCartItemMapper : DALAbstractShoppingCartItemMapper, IDALShoppingCartItemMapper
        {
                public DALShoppingCartItemMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>eb26721c121702bfca34a57a8273336b</Hash>
</Codenesium>*/