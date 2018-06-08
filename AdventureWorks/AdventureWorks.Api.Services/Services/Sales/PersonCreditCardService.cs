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
                        IDALPersonCreditCardMapper dalpersonCreditCardMapper)
                        : base(logger,
                               personCreditCardRepository,
                               personCreditCardModelValidator,
                               bolpersonCreditCardMapper,
                               dalpersonCreditCardMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bbed904bb9351dc0f2deef46c5195dcc</Hash>
</Codenesium>*/