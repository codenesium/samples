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
                        ILogger<ITransactionHistoryArchiveRepository> logger,
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
    <Hash>dcfcf4f4536d46b98d3e2973e07436ef</Hash>
</Codenesium>*/