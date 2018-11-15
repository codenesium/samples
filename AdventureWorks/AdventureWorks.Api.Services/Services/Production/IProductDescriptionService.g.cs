using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductDescriptionService
	{
		Task<CreateResponse<ApiProductDescriptionServerResponseModel>> Create(
			ApiProductDescriptionServerRequestModel model);

		Task<UpdateResponse<ApiProductDescriptionServerResponseModel>> Update(int productDescriptionID,
		                                                                       ApiProductDescriptionServerRequestModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		Task<ApiProductDescriptionServerResponseModel> Get(int productDescriptionID);

		Task<List<ApiProductDescriptionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductDescriptionServerResponseModel> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>69ede4ab47987b4df1256c428a2f4c9b</Hash>
</Codenesium>*/