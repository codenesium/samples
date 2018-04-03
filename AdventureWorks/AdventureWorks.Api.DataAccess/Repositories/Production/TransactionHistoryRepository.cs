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
		public TransactionHistoryRepository(ILogger<TransactionHistoryRepository> logger,
		                                    ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFTransactionHistory> SearchLinqEF(Expression<Func<EFTransactionHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy("transactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
			else
			{
				return this._context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
		}

		protected override List<EFTransactionHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy("transactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
			else
			{
				return this._context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>74ffd8da901001a8f8880a904f85e503</Hash>
</Codenesium>*/