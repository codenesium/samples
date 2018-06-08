using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALCreditCardMapper
        {
                CreditCard MapBOToEF(
                        BOCreditCard bo);

                BOCreditCard MapEFToBO(
                        CreditCard efCreditCard);

                List<BOCreditCard> MapEFToBO(
                        List<CreditCard> records);
        }
}

/*<Codenesium>
    <Hash>54ebf95823abc7fc34df2916d52cb37e</Hash>
</Codenesium>*/