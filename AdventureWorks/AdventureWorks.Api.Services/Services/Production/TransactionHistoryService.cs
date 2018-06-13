using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class TransactionHistoryService: AbstractTransactionHistoryService, ITransactionHistoryService
        {
                public TransactionHistoryService(
                        ILogger<TransactionHistoryRepository> logger,
                        ITransactionHistoryRepository transactionHistoryRepository,
                        IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
                        IBOLTransactionHistoryMapper boltransactionHistoryMapper,
                        IDALTransactionHistoryMapper daltransactionHistoryMapper

                        )
                        : base(logger,
                               transactionHistoryRepository,
                               transactionHistoryModelValidator,
                               boltransactionHistoryMapper,
                               daltransactionHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>01d1392579fa569eb63c4b5eee80003c</Hash>
</Codenesium>*/