using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IStoreRepository
        {
                Task<Store> Create(Store item);

                Task Update(Store item);

                Task Delete(int businessEntityID);

                Task<Store> Get(int businessEntityID);

                Task<List<Store>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Store>> GetSalesPersonID(Nullable<int> salesPersonID);
                Task<List<Store>> GetDemographics(string demographics);

                Task<List<Customer>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8756f381bd195c8826ecdd0f9652fa7d</Hash>
</Codenesium>*/