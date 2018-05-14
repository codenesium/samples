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

		POCOTransactionHistory Get(int transactionID);

		List<POCOTransactionHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistory> GetProductID(int productID);
		List<POCOTransactionHistory> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>13e8446adb6f678223fab8130d73fc53</Hash>
</Codenesium>*/