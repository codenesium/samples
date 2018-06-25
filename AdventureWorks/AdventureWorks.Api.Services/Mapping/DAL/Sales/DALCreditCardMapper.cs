using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALCreditCardMapper : DALAbstractCreditCardMapper, IDALCreditCardMapper
        {
                public DALCreditCardMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>03d1f4399e11ad6ba6dad29c3e99324e</Hash>
</Codenesium>*/