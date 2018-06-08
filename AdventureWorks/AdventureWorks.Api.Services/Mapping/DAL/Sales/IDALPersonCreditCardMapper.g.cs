using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>2552497d308ba40d8ae42b93382d402f</Hash>
</Codenesium>*/