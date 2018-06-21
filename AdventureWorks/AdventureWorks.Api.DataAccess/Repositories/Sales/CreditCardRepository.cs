using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>45230648c73c2c83d9caad20d0c7d8a7</Hash>
</Codenesium>*/