using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IStateProvinceRepository
	{
		Task<StateProvince> Create(StateProvince item);

		Task Update(StateProvince item);

		Task Delete(int stateProvinceID);

		Task<StateProvince> Get(int stateProvinceID);

		Task<List<StateProvince>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<StateProvince> ByName(string name);

		Task<StateProvince> ByRowguid(Guid rowguid);

		Task<StateProvince> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

		Task<List<Address>> AddressesByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0);

		Task<CountryRegion> CountryRegionByCountryRegionCode(string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>8d711fab1aef6e746a727a4792065f61</Hash>
</Codenesium>*/