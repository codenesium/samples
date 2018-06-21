using Codenesium.DataConversionExtensions;
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
    <Hash>4472c69259d6dd34b90b6312f2bf215e</Hash>
</Codenesium>*/