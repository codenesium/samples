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
        public class TransactionHistoryArchiveService: AbstractTransactionHistoryArchiveService, ITransactionHistoryArchiveService
        {
                public TransactionHistoryArchiveService(
                        ILogger<TransactionHistoryArchiveRepository> logger,
                        ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
                        IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
                        IBOLTransactionHistoryArchiveMapper boltransactionHistoryArchiveMapper,
                        IDALTransactionHistoryArchiveMapper daltransactionHistoryArchiveMapper)
                        : base(logger,
                               transactionHistoryArchiveRepository,
                               transactionHistoryArchiveModelValidator,
                               boltransactionHistoryArchiveMapper,
                               daltransactionHistoryArchiveMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2d00e2c116fc202e9f6261f0f6ad22a4</Hash>
</Codenesium>*/