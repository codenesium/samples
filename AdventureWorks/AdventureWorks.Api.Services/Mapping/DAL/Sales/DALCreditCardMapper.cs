using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALCreditCardMapper : DALAbstractCreditCardMapper, IDALCreditCardMapper
        {
                public DALCreditCardMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a224bf06ca28bc7363f034a4cad755fe</Hash>
</Codenesium>*/