using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductSubcategoryService
	{
		Task<CreateResponse<ApiProductSubcategoryResponseModel>> Create(
			ApiProductSubcategoryRequestModel model);

		Task<ActionResponse> Update(int productSubcategoryID,
		                            ApiProductSubcategoryRequestModel model);

		Task<ActionResponse> Delete(int productSubcategoryID);

		Task<ApiProductSubcategoryResponseModel> Get(int productSubcategoryID);

		Task<List<ApiProductSubcategoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiProductSubcategoryResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>c5a87c5001f9406d36fb6bb43b19f655</Hash>
</Codenesium>*/