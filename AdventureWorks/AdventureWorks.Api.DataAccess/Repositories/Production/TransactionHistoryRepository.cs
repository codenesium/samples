using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class TransactionHistoryRepository : AbstractTransactionHistoryRepository, ITransactionHistoryRepository
        {
                public TransactionHistoryRepository(
                        ILogger<TransactionHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6334cc807d01804e0262813371a1bc46</Hash>
</Codenesium>*/