using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CreditCardRepository: AbstractCreditCardRepository, ICreditCardRepository
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
    <Hash>7bdf1585e9d3bec685c588c633f6ce95</Hash>
</Codenesium>*/