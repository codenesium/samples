using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
	{
		int Create(TransactionHistoryArchiveModel model);

		void Update(int transactionID,
		            TransactionHistoryArchiveModel model);

		void Delete(int transactionID);

		POCOTransactionHistoryArchive Get(int transactionID);

		List<POCOTransactionHistoryArchive> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>42401d80d6884d0b261a42fc0b11fc49</Hash>
</Codenesium>*/