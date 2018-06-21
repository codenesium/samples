using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>37f84db8c25347629a904d24201e6a82</Hash>
</Codenesium>*/