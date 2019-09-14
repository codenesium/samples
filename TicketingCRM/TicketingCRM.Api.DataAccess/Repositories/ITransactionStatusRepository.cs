using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITransactionStatusRepository
	{
		Task<TransactionStatus> Create(TransactionStatus item);

		Task Update(TransactionStatus item);

		Task Delete(int id);

		Task<TransactionStatus> Get(int id);

		Task<List<TransactionStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Transaction>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9bf0cab3d1c123dd1e5a8699424cda47</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/