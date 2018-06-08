using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PersonCreditCardRepository: AbstractPersonCreditCardRepository, IPersonCreditCardRepository
        {
                public PersonCreditCardRepository(
                        ILogger<PersonCreditCardRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ddff88eeb1d4881d2c1d2e4d29f7a46a</Hash>
</Codenesium>*/