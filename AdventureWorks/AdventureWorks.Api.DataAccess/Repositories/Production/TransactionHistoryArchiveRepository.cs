using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class TransactionHistoryArchiveRepository : AbstractTransactionHistoryArchiveRepository, ITransactionHistoryArchiveRepository
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
    <Hash>2cd6cf63909728c0ad7027633919a061</Hash>
</Codenesium>*/