using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductModelService
	{
		Task<CreateResponse<ApiProductModelResponseModel>> Create(
			ApiProductModelRequestModel model);

		Task<UpdateResponse<ApiProductModelResponseModel>> Update(int productModelID,
		                                                           ApiProductModelRequestModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<ApiProductModelResponseModel> Get(int productModelID);

		Task<List<ApiProductModelResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductModelResponseModel> ByName(string name);

		Task<List<ApiProductModelResponseModel>> ByCatalogDescription(string catalogDescription, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelResponseModel>> ByInstruction(string instruction, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductResponseModel>> Products(int productModelID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8dd0f99668571fc93174024f143c65d8</Hash>
</Codenesium>*/