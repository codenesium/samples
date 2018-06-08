using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class TransactionHistoryRepository: AbstractTransactionHistoryRepository, ITransactionHistoryRepository
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
    <Hash>ade990e200bb127f32de86778de716f7</Hash>
</Codenesium>*/