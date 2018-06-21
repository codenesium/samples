using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class PersonCreditCardService : AbstractPersonCreditCardService, IPersonCreditCardService
        {
                public PersonCreditCardService(
                        ILogger<IPersonCreditCardRepository> logger,
                        IPersonCreditCardRepository personCreditCardRepository,
                        IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
                        IBOLPersonCreditCardMapper bolpersonCreditCardMapper,
                        IDALPersonCreditCardMapper dalpersonCreditCardMapper
                        )
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
    <Hash>ff7ce2a35ac19edf6908a48d97eaa5d1</Hash>
</Codenesium>*/