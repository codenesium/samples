using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class PersonCreditCardService: AbstractPersonCreditCardService, IPersonCreditCardService
        {
                public PersonCreditCardService(
                        ILogger<PersonCreditCardRepository> logger,
                        IPersonCreditCardRepository personCreditCardRepository,
                        IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
                        IBOLPersonCreditCardMapper bolpersonCreditCardMapper,
                        IDALPersonCreditCardMapper dalpersonCreditCardMapper

                        )
                        : base(logger,
                               personCreditCardRepository,
                               personCreditCardModelValidator,
                               bolpersonCreditCardMapper,
                               dalpersonCreditCardMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d2d9cd3d7bfd7ce704f56f95a5a2e349</Hash>
</Codenesium>*/