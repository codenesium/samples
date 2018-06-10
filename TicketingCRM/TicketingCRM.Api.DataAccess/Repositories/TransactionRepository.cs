using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class TransactionRepository: AbstractTransactionRepository, ITransactionRepository
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
    <Hash>3621f496552f270bc27ac6657129a29b</Hash>
</Codenesium>*/