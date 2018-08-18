using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICultureService
	{
		Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model);

		Task<UpdateResponse<ApiCultureResponseModel>> Update(string cultureID,
		                                                      ApiCultureRequestModel model);

		Task<ActionResponse> Delete(string cultureID);

		Task<ApiCultureResponseModel> Get(string cultureID);

		Task<List<ApiCultureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCultureResponseModel> ByName(string name);

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(string cultureID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>86abe1c7533674f92a9f256ba59afbd1</Hash>
</Codenesium>*/