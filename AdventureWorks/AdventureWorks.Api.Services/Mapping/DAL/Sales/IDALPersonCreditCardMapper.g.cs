using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALPersonCreditCardMapper
        {
                PersonCreditCard MapBOToEF(
                        BOPersonCreditCard bo);

                BOPersonCreditCard MapEFToBO(
                        PersonCreditCard efPersonCreditCard);

                List<BOPersonCreditCard> MapEFToBO(
                        List<PersonCreditCard> records);
        }
}

/*<Codenesium>
    <Hash>ba1d8ed9a6870d307dbd4956ec2d4078</Hash>
</Codenesium>*/