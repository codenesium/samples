using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOTransactionHistoryArchive
	{
		Task<CreateResponse<int>> Create(
			TransactionHistoryArchiveModel model);

		Task<ActionResponse> Update(int transactionID,
		                            TransactionHistoryArchiveModel model);

		Task<ActionResponse> Delete(int transactionID);

		ApiResponse GetById(int transactionID);

		POCOTransactionHistoryArchive GetByIdDirect(int transactionID);

		ApiResponse GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistoryArchive> GetWhereDirect(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4273fbc936961b4d361a2b9740076b27</Hash>
</Codenesium>*/