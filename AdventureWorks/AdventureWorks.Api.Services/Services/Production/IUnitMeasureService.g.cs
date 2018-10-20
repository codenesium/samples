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

		Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductResponseModel>> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductResponseModel>> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c32e43b739702981f80e9de80bf593c9</Hash>
</Codenesium>*/