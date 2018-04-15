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
	public class TransactionHistoryArchiveRepository: AbstractTransactionHistoryArchiveRepository, ITransactionHistoryArchiveRepository
	{
		public TransactionHistoryArchiveRepository(
			IObjectMapper mapper,
			ILogger<TransactionHistoryArchiveRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFTransactionHistoryArchive> SearchLinqEF(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy("TransactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
			else
			{
				return this.context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
		}

		protected override List<EFTransactionHistoryArchive> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy("TransactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
			else
			{
				return this.context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>b20b6cb4c99bac9c82bf6b5d9f7d62cf</Hash>
</Codenesium>*/