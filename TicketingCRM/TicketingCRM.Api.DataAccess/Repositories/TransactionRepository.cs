using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class TransactionRepository : AbstractTransactionRepository, ITransactionRepository
        {
                public TransactionRepository(
                        ILogger<TransactionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ca73656db8d2b508cf2e71d69e0d2da3</Hash>
</Codenesium>*/