using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class TransactionHistoryService : AbstractTransactionHistoryService, ITransactionHistoryService
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
                               daltransactionHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>186c8ad978967381257a692fb5e39814</Hash>
</Codenesium>*/