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
                        IDALTransactionHistoryArchiveMapper daltransactionHistoryArchiveMapper

                        )
                        : base(logger,
                               transactionHistoryArchiveRepository,
                               transactionHistoryArchiveModelValidator,
                               boltransactionHistoryArchiveMapper,
                               daltransactionHistoryArchiveMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a4f816aa4a3a222fefbd1c27b4f11c80</Hash>
</Codenesium>*/