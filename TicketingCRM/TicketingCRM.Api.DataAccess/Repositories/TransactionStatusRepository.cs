using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>18198b37c28fd22eef1b25bcd9d387c8</Hash>
</Codenesium>*/