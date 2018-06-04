using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductCategoryService
	{
		Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
			ApiProductCategoryRequestModel model);

		Task<ActionResponse> Update(int productCategoryID,
		                            ApiProductCategoryRequestModel model);

		Task<ActionResponse> Delete(int productCategoryID);

		Task<ApiProductCategoryResponseModel> Get(int productCategoryID);

		Task<List<ApiProductCategoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiProductCategoryResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>f301256ece55c362b7b895531495be81</Hash>
</Codenesium>*/