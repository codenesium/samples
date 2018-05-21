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
		Task<CreateResponse<POCOTransactionHistoryArchive>> Create(
			ApiTransactionHistoryArchiveModel model);

		Task<ActionResponse> Update(int transactionID,
		                            ApiTransactionHistoryArchiveModel model);

		Task<ActionResponse> Delete(int transactionID);

		Task<POCOTransactionHistoryArchive> Get(int transactionID);

		Task<List<POCOTransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOTransactionHistoryArchive>> GetProductID(int productID);
		Task<List<POCOTransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>6c42030a33888afb7c99dcfbe84ade18</Hash>
</Codenesium>*/