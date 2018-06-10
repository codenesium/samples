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
                        IDALTransactionStatusMapper daltransactionStatusMapper)
                        : base(logger,
                               transactionStatusRepository,
                               transactionStatusModelValidator,
                               boltransactionStatusMapper,
                               daltransactionStatusMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3d142491af4cea270fa3b8c1a6bc9a7a</Hash>
</Codenesium>*/