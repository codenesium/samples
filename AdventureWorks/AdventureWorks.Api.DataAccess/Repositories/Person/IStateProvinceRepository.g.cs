using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IStateProvinceRepository
        {
                Task<StateProvince> Create(StateProvince item);

                Task Update(StateProvince item);

                Task Delete(int stateProvinceID);

                Task<StateProvince> Get(int stateProvinceID);

                Task<List<StateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<StateProvince> GetName(string name);
                Task<StateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);
        }
}

/*<Codenesium>
    <Hash>d6a0fd7b04b0e0d42bcb3cab3eff4793</Hash>
</Codenesium>*/