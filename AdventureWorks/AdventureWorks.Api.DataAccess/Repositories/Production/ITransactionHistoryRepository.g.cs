using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryRepository
	{
		int Create(TransactionHistoryModel model);

		void Update(int transactionID,
		            TransactionHistoryModel model);

		void Delete(int transactionID);

		ApiResponse GetById(int transactionID);

		POCOTransactionHistory GetByIdDirect(int transactionID);

		ApiResponse GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistory> GetWhereDirect(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c95db97137edcac54a426c768bd68a18</Hash>
</Codenesium>*/