using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ICountryRegionService
	{
		Task<CreateResponse<ApiCountryRegionResponseModel>> Create(
			ApiCountryRegionRequestModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            ApiCountryRegionRequestModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		Task<ApiCountryRegionResponseModel> Get(string countryRegionCode);

		Task<List<ApiCountryRegionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiCountryRegionResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>50b9bad8b2f3005b9295fdbdcda1c003</Hash>
</Codenesium>*/