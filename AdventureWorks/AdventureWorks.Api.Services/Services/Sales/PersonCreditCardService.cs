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
                               dalpersonCreditCardMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>45d842f78d255458ba60648c82fae748</Hash>
</Codenesium>*/