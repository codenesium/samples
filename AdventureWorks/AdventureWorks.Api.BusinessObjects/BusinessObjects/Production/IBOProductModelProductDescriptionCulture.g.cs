using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModelProductDescriptionCulture
	{
		Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
			ApiProductModelProductDescriptionCultureRequestModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ApiProductModelProductDescriptionCultureRequestModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID);

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3c8101ab8f1e694337ebce04e7f39d49</Hash>
</Codenesium>*/