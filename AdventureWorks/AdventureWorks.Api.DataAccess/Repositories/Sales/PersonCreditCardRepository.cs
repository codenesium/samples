using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class PersonCreditCardRepository : AbstractPersonCreditCardRepository, IPersonCreditCardRepository
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
    <Hash>4db83b47a36e56034bfd3a2480c13dfe</Hash>
</Codenesium>*/