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

                Task<List<Store>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Store>> BySalesPersonID(Nullable<int> salesPersonID);
                Task<List<Store>> ByDemographics(string demographics);

                Task<List<Customer>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);

                Task<SalesPerson> GetSalesPerson(int salesPersonID);
        }
}

/*<Codenesium>
    <Hash>852af8026a2b7c55e7163668bf2784b2</Hash>
</Codenesium>*/