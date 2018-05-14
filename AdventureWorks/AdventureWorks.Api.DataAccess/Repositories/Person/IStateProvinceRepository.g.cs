using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStateProvinceRepository
	{
		POCOStateProvince Create(ApiStateProvinceModel model);

		void Update(int stateProvinceID,
		            ApiStateProvinceModel model);

		void Delete(int stateProvinceID);

		POCOStateProvince Get(int stateProvinceID);

		List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOStateProvince GetName(string name);

		POCOStateProvince GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>97bbfb87c72053ffab437ef74f733fd4</Hash>
</Codenesium>*/