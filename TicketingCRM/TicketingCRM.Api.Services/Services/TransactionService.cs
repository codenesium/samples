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
                        IDALTransactionMapper daltransactionMapper
                        ,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper

                        )
                        : base(logger,
                               transactionRepository,
                               transactionModelValidator,
                               boltransactionMapper,
                               daltransactionMapper
                               ,
                               bolSaleMapper,
                               dalSaleMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>936060326959c66715e36a3ee5835084</Hash>
</Codenesium>*/