using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductSubcategory
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
    <Hash>f524eca28958911710cba075fdfcc703</Hash>
</Codenesium>*/