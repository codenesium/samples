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
		{}
	}
}

/*<Codenesium>
    <Hash>f14396723de0c0bdc82a4eb2822a89be</Hash>
</Codenesium>*/