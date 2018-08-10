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
    <Hash>01a571459345374772314f59f8cb8182</Hash>
</Codenesium>*/