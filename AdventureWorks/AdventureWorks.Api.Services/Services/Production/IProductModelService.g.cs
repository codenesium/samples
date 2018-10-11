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

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelResponseModel>> ByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4d1ba184c79fad1445e6d134c713cfe6</Hash>
</Codenesium>*/