using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

                Task<List<Store>> BySalesPersonID(int? salesPersonID);

                Task<List<Store>> ByDemographics(string demographics);

                Task<List<Customer>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);

                Task<SalesPerson> GetSalesPerson(int? salesPersonID);
        }
}

/*<Codenesium>
    <Hash>628321b48b9503e478838c4c82faa8bd</Hash>
</Codenesium>*/