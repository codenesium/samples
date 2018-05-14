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

		POCOTransactionHistoryArchive Get(int transactionID);

		List<POCOTransactionHistoryArchive> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistoryArchive> GetProductID(int productID);
		List<POCOTransactionHistoryArchive> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>f06015faf6d691e4ab924ea434f90c6b</Hash>
</Codenesium>*/