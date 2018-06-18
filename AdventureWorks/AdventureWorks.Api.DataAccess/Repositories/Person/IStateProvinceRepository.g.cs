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

                Task<List<StateProvince>> All(int limit = int.MaxValue, int offset = 0);

                Task<StateProvince> ByName(string name);
                Task<StateProvince> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

                Task<List<Address>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5ea9b915ce9f0b7787712ca47072526b</Hash>
</Codenesium>*/