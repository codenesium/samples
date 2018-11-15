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

		Task<List<StateProvince>> All(int limit = int.MaxValue, int offset = 0);

		Task<StateProvince> ByName(string name);

		Task<StateProvince> ByRowguid(Guid rowguid);

		Task<StateProvince> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

		Task<List<Address>> AddressesByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>553facaa06ef6d2f618bf85d8f1d58ca</Hash>
</Codenesium>*/