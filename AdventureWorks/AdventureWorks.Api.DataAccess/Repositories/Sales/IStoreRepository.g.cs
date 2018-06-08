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

                Task<List<Store>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Store>> GetSalesPersonID(Nullable<int> salesPersonID);
                Task<List<Store>> GetDemographics(string demographics);
        }
}

/*<Codenesium>
    <Hash>5d04f788b243afc058f1cf6067d83358</Hash>
</Codenesium>*/