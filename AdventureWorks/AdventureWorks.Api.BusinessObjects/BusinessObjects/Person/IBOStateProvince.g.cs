using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOStateProvince
	{
		Task<CreateResponse<POCOStateProvince>> Create(
			ApiStateProvinceModel model);

		Task<ActionResponse> Update(int stateProvinceID,
		                            ApiStateProvinceModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		POCOStateProvince Get(int stateProvinceID);

		List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOStateProvince GetName(string name);

		POCOStateProvince GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>567ced9de86141ec5aa8e3a29c23bffc</Hash>
</Codenesium>*/