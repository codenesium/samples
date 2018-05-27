using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
	{
		Task<DTOTransactionHistoryArchive> Create(DTOTransactionHistoryArchive dto);

		Task Update(int transactionID,
		            DTOTransactionHistoryArchive dto);

		Task Delete(int transactionID);

		Task<DTOTransactionHistoryArchive> Get(int transactionID);

		Task<List<DTOTransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOTransactionHistoryArchive>> GetProductID(int productID);
		Task<List<DTOTransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>0717fdb3819e410182d6a2c37f437358</Hash>
</Codenesium>*/