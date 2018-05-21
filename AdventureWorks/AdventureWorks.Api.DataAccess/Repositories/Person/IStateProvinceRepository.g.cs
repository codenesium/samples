using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStateProvinceRepository
	{
		Task<POCOStateProvince> Create(ApiStateProvinceModel model);

		Task Update(int stateProvinceID,
		            ApiStateProvinceModel model);

		Task Delete(int stateProvinceID);

		Task<POCOStateProvince> Get(int stateProvinceID);

		Task<List<POCOStateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOStateProvince> GetName(string name);
		Task<POCOStateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>6828bf0e500a5a8065dfe407f968a1c9</Hash>
</Codenesium>*/