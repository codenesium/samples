using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALCreditCardMapper: DALAbstractCreditCardMapper, IDALCreditCardMapper
        {
                public DALCreditCardMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d677fa23bda61d22022892b7928d2042</Hash>
</Codenesium>*/