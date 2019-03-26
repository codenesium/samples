using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>69fd78be605f9d8944f025bbf2b5c001</Hash>
</Codenesium>*/