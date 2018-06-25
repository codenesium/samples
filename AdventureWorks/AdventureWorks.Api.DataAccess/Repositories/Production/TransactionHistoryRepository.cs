using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class TransactionHistoryRepository : AbstractTransactionHistoryRepository, ITransactionHistoryRepository
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
    <Hash>042732aa8c09069b8b9250bf7d48eaa9</Hash>
</Codenesium>*/