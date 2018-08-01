using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductDescriptionService
	{
		Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
			ApiProductDescriptionRequestModel model);

		Task<UpdateResponse<ApiProductDescriptionResponseModel>> Update(int productDescriptionID,
		                                                                 ApiProductDescriptionRequestModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID);

		Task<List<ApiProductDescriptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productDescriptionID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>58ebf40403cb059be5ed5f271cd8435e</Hash>
</Codenesium>*/