using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOTransactionHistory
	{
		Task<CreateResponse<int>> Create(
			TransactionHistoryModel model);

		Task<ActionResponse> Update(int transactionID,
		                            TransactionHistoryModel model);

		Task<ActionResponse> Delete(int transactionID);

		ApiResponse GetById(int transactionID);

		POCOTransactionHistory GetByIdDirect(int transactionID);

		ApiResponse GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistory> GetWhereDirect(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c1ec04cfb17ad257c107379fd0b90950</Hash>
</Codenesium>*/