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
		Task<CreateResponse<POCOTransactionHistory>> Create(
			ApiTransactionHistoryModel model);

		Task<ActionResponse> Update(int transactionID,
		                            ApiTransactionHistoryModel model);

		Task<ActionResponse> Delete(int transactionID);

		Task<POCOTransactionHistory> Get(int transactionID);

		Task<List<POCOTransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOTransactionHistory>> GetProductID(int productID);
		Task<List<POCOTransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>336b5d813f8f06a4bef1857ff11dab5d</Hash>
</Codenesium>*/