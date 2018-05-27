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
		Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
			ApiStateProvinceRequestModel model);

		Task<ActionResponse> Update(int stateProvinceID,
		                            ApiStateProvinceRequestModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		Task<ApiStateProvinceResponseModel> Get(int stateProvinceID);

		Task<List<ApiStateProvinceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiStateProvinceResponseModel> GetName(string name);
		Task<ApiStateProvinceResponseModel> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>db04747c6b8226b2f24c604839151233</Hash>
</Codenesium>*/