using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ICultureService
	{
		Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model);

		Task<ActionResponse> Update(string cultureID,
		                            ApiCultureRequestModel model);

		Task<ActionResponse> Delete(string cultureID);

		Task<ApiCultureResponseModel> Get(string cultureID);

		Task<List<ApiCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiCultureResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>b1a9384a917dee9ccb28b445d97d00dd</Hash>
</Codenesium>*/