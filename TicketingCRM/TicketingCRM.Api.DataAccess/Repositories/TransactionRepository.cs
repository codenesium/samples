using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class TransactionRepository : AbstractTransactionRepository, ITransactionRepository
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
    <Hash>b482d7fc1b09c625f8e08ffd3f66d25a</Hash>
</Codenesium>*/