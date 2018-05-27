using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductCategory
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
    <Hash>8125fdb16fa35d63f2be615444c9104e</Hash>
</Codenesium>*/