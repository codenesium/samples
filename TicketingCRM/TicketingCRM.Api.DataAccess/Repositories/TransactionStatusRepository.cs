using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class TransactionStatusRepository : AbstractTransactionStatusRepository, ITransactionStatusRepository
        {
                public TransactionStatusRepository(
                        ILogger<TransactionStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ec8e0c07a5b531f29e277bf537d3e12f</Hash>
</Codenesium>*/