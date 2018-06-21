using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>fd928a41ffb0d89293ddf199f989c54e</Hash>
</Codenesium>*/