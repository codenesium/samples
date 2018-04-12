using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class TransactionHistoryRepository: AbstractTransactionHistoryRepository, ITransactionHistoryRepository
	{
		public TransactionHistoryRepository(
			ILogger<TransactionHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFTransactionHistory> SearchLinqEF(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy("TransactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
			else
			{
				return this.context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
		}

		protected override List<EFTransactionHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy("TransactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
			else
			{
				return this.context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>bf9cfc70b11edd168cb4daa16e2a1b43</Hash>
</Codenesium>*/