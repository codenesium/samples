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

                Task<List<StateProvince>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<StateProvince> GetName(string name);
                Task<StateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

                Task<List<Address>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0a32fad1fa3ba0002d93dc0eec9cea3c</Hash>
</Codenesium>*/