using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CreditCardRepository : AbstractCreditCardRepository, ICreditCardRepository
        {
                public CreditCardRepository(
                        ILogger<CreditCardRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9c9af35fa3f90e4cb77a810a88afd5fb</Hash>
</Codenesium>*/