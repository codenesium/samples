using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ITransactionHistoryRepository
        {
                Task<TransactionHistory> Create(TransactionHistory item);

                Task Update(TransactionHistory item);

                Task Delete(int transactionID);

                Task<TransactionHistory> Get(int transactionID);

                Task<List<TransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<TransactionHistory>> GetProductID(int productID);
                Task<List<TransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>98815c75895f0c4705fb1ddf58803694</Hash>
</Codenesium>*/