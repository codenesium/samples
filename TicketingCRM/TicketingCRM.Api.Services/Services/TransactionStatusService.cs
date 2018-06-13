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
        public class TransactionStatusService: AbstractTransactionStatusService, ITransactionStatusService
        {
                public TransactionStatusService(
                        ILogger<TransactionStatusRepository> logger,
                        ITransactionStatusRepository transactionStatusRepository,
                        IApiTransactionStatusRequestModelValidator transactionStatusModelValidator,
                        IBOLTransactionStatusMapper boltransactionStatusMapper,
                        IDALTransactionStatusMapper daltransactionStatusMapper
                        ,
                        IBOLTransactionMapper bolTransactionMapper,
                        IDALTransactionMapper dalTransactionMapper

                        )
                        : base(logger,
                               transactionStatusRepository,
                               transactionStatusModelValidator,
                               boltransactionStatusMapper,
                               daltransactionStatusMapper
                               ,
                               bolTransactionMapper,
                               dalTransactionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f44a160f5eda1f5f2ac3ead6a6bb7703</Hash>
</Codenesium>*/