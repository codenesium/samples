using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IUnitMeasureService
	{
		Task<CreateResponse<ApiUnitMeasureServerResponseModel>> Create(
			ApiUnitMeasureServerRequestModel model);

		Task<UpdateResponse<ApiUnitMeasureServerResponseModel>> Update(string unitMeasureCode,
		                                                                ApiUnitMeasureServerRequestModel model);

		Task<ActionResponse> Delete(string unitMeasureCode);

		Task<ApiUnitMeasureServerResponseModel> Get(string unitMeasureCode);

		Task<List<ApiUnitMeasureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiUnitMeasureServerResponseModel> ByName(string name);

		Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductServerResponseModel>> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductServerResponseModel>> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1530d7de86cda9d9bdeb4b2c3008e2cd</Hash>
</Codenesium>*/