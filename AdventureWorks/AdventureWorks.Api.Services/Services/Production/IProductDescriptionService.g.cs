using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductDescriptionService
	{
		Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
			ApiProductDescriptionRequestModel model);

		Task<UpdateResponse<ApiProductDescriptionResponseModel>> Update(int productDescriptionID,
		                                                                 ApiProductDescriptionRequestModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID);

		Task<List<ApiProductDescriptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCulturesByProductDescriptionID(int productDescriptionID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b72b571f8d15490aaca169f9bc944c0b</Hash>
</Codenesium>*/