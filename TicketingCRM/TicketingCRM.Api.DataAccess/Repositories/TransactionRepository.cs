using Codenesium.DataConversionExtensions;
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
    <Hash>b97ee6fb335507f79de922f9ad64d9b2</Hash>
</Codenesium>*/