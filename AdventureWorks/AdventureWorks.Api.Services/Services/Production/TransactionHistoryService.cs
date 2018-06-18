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
                        ILogger<ITransactionHistoryRepository> logger,
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
    <Hash>e9f58d3b06c9564f32de69439b4810a6</Hash>
</Codenesium>*/