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

		POCOTransactionHistoryArchive Get(int transactionID);

		List<POCOTransactionHistoryArchive> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a18f4d1ecc579a1063ede7c7a72db633</Hash>
</Codenesium>*/