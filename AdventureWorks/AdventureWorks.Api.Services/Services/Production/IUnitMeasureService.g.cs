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
    <Hash>5e9e2789cd1d59f9eb822b1f7d72a4e1</Hash>
</Codenesium>*/