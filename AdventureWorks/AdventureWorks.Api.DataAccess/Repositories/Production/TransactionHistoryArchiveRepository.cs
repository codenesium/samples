using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class TransactionHistoryArchiveRepository : AbstractTransactionHistoryArchiveRepository, ITransactionHistoryArchiveRepository
        {
                public TransactionHistoryArchiveRepository(
                        ILogger<TransactionHistoryArchiveRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bb286f6e9db86c29ef766ef2f48cc5de</Hash>
</Codenesium>*/