using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class CreditCardRepository : AbstractCreditCardRepository, ICreditCardRepository
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
    <Hash>48dbe5f7fd59ccf7ef65eb95aec163a2</Hash>
</Codenesium>*/