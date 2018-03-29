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
		public TransactionHistoryArchiveRepository(ILogger<TransactionHistoryArchiveRepository> logger,
		                                           ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFTransactionHistoryArchive> SearchLinqEF(Expression<Func<EFTransactionHistoryArchive, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy("TransactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
			else
			{
				return this._context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
		}

		protected override List<EFTransactionHistoryArchive> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy("TransactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
			else
			{
				return this._context.Set<EFTransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistoryArchive>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a332d41a801efd1bb6b41e52d086576f</Hash>
</Codenesium>*/