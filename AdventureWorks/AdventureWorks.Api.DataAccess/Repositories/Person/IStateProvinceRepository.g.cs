using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IStateProvinceRepository
        {
                Task<StateProvince> Create(StateProvince item);

                Task Update(StateProvince item);

                Task Delete(int stateProvinceID);

                Task<StateProvince> Get(int stateProvinceID);

                Task<List<StateProvince>> All(int limit = int.MaxValue, int offset = 0);

                Task<StateProvince> ByName(string name);

                Task<StateProvince> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

                Task<List<Address>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>43801517241233d7f2ab40c9eb593047</Hash>
</Codenesium>*/