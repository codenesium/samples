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

		Task<List<ApiProductDescriptionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiProductDescriptionServerResponseModel> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>5fa35e19ec9eb870f8f9b907e136b349</Hash>
</Codenesium>*/