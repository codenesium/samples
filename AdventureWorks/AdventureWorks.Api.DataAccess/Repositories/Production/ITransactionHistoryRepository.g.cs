using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryRepository
	{
		Task<POCOTransactionHistory> Create(ApiTransactionHistoryModel model);

		Task Update(int transactionID,
		            ApiTransactionHistoryModel model);

		Task Delete(int transactionID);

		Task<POCOTransactionHistory> Get(int transactionID);

		Task<List<POCOTransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOTransactionHistory>> GetProductID(int productID);
		Task<List<POCOTransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>14a1b7992242471f85a5d5d173d71994</Hash>
</Codenesium>*/