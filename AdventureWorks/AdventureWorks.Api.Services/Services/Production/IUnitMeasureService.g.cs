using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IUnitMeasureService
	{
		Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
			ApiUnitMeasureRequestModel model);

		Task<UpdateResponse<ApiUnitMeasureResponseModel>> Update(string unitMeasureCode,
		                                                          ApiUnitMeasureRequestModel model);

		Task<ActionResponse> Delete(string unitMeasureCode);

		Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode);

		Task<List<ApiUnitMeasureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiUnitMeasureResponseModel> ByName(string name);

		Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductResponseModel>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5ce7e00ba762547e21ab52cd7a7c9f8b</Hash>
</Codenesium>*/