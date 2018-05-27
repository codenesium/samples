using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryRepository
	{
		Task<DTOTransactionHistory> Create(DTOTransactionHistory dto);

		Task Update(int transactionID,
		            DTOTransactionHistory dto);

		Task Delete(int transactionID);

		Task<DTOTransactionHistory> Get(int transactionID);

		Task<List<DTOTransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOTransactionHistory>> GetProductID(int productID);
		Task<List<DTOTransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>83d4d8a177f85f4dcd2f19daf5e5a930</Hash>
</Codenesium>*/