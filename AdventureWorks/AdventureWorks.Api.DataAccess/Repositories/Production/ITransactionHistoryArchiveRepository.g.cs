using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
	{
		Task<POCOTransactionHistoryArchive> Create(ApiTransactionHistoryArchiveModel model);

		Task Update(int transactionID,
		            ApiTransactionHistoryArchiveModel model);

		Task Delete(int transactionID);

		Task<POCOTransactionHistoryArchive> Get(int transactionID);

		Task<List<POCOTransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOTransactionHistoryArchive>> GetProductID(int productID);
		Task<List<POCOTransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>1693810f14c69cf35949a11c9cab2433</Hash>
</Codenesium>*/