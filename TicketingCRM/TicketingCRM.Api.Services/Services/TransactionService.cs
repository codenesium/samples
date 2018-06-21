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
        public class TransactionService : AbstractTransactionService, ITransactionService
        {
                public TransactionService(
                        ILogger<ITransactionRepository> logger,
                        ITransactionRepository transactionRepository,
                        IApiTransactionRequestModelValidator transactionModelValidator,
                        IBOLTransactionMapper boltransactionMapper,
                        IDALTransactionMapper daltransactionMapper,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper
                        )
                        : base(logger,
                               transactionRepository,
                               transactionModelValidator,
                               boltransactionMapper,
                               daltransactionMapper,
                               bolSaleMapper,
                               dalSaleMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4fca7df147c6e0da5b5647a53afd1544</Hash>
</Codenesium>*/