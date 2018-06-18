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
                        ILogger<ITransactionStatusRepository> logger,
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
    <Hash>3456fa280f70d3a637c08f68be082ae2</Hash>
</Codenesium>*/