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
		Task<StateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>04653f9027c7cdbf5226013947a71d9f</Hash>
</Codenesium>*/