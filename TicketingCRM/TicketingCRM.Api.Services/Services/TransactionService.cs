using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class TransactionService: AbstractTransactionService, ITransactionService
        {
                public TransactionService(
                        ILogger<TransactionRepository> logger,
                        ITransactionRepository transactionRepository,
                        IApiTransactionRequestModelValidator transactionModelValidator,
                        IBOLTransactionMapper boltransactionMapper,
                        IDALTransactionMapper daltransactionMapper)
                        : base(logger,
                               transactionRepository,
                               transactionModelValidator,
                               boltransactionMapper,
                               daltransactionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>58edd3bed390957fd429f196f7523ec4</Hash>
</Codenesium>*/