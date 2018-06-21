using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PersonCreditCardRepository : AbstractPersonCreditCardRepository, IPersonCreditCardRepository
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
    <Hash>b7ecf0866c85c78e85fa13949d98d250</Hash>
</Codenesium>*/