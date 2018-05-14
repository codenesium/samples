using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
	{
		POCOTransactionHistoryArchive Create(ApiTransactionHistoryArchiveModel model);

		void Update(int transactionID,
		            ApiTransactionHistoryArchiveModel model);

		void Delete(int transactionID);

		POCOTransactionHistoryArchive Get(int transactionID);

		List<POCOTransactionHistoryArchive> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistoryArchive> GetProductID(int productID);
		List<POCOTransactionHistoryArchive> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>72fac744c12c353f7a6272a4b4e929fd</Hash>
</Codenesium>*/