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

		POCOTransactionHistory Get(int transactionID);

		List<POCOTransactionHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>86a032abc4234ddd347c37d5a5cb7d50</Hash>
</Codenesium>*/