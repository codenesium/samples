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
		                                    ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFTransactionHistory> SearchLinqEF(Expression<Func<EFTransactionHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy("TransactionID ASC").Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
			else
			{
				return this.context.Set<EFTransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTransactionHistory>();
			}
		}

		protected override List<EFTransactionHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
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
    <Hash>e464ffa2645cda7216349f1496072557</Hash>
</Codenesium>*/