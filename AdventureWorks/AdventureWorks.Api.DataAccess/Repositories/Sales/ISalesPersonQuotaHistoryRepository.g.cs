using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesPersonQuotaHistoryRepository
        {
                Task<SalesPersonQuotaHistory> Create(SalesPersonQuotaHistory item);

                Task Update(SalesPersonQuotaHistory item);

                Task Delete(int businessEntityID);

                Task<SalesPersonQuotaHistory> Get(int businessEntityID);

                Task<List<SalesPersonQuotaHistory>> All(int limit = int.MaxValue, int offset = 0);

                Task<SalesPerson> GetSalesPerson(int businessEntityID);
        }
}

/*<Codenesium>
    <Hash>ea13e2c2ebb8bb543e58eb83c5e7b336</Hash>
</Codenesium>*/