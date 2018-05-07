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

		POCOTransactionHistory Get(int transactionID);

		List<POCOTransactionHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>40362eb88a0b267cae619ad16a0ba12d</Hash>
</Codenesium>*/