using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBillOfMaterialService
	{
		Task<CreateResponse<ApiBillOfMaterialResponseModel>> Create(
			ApiBillOfMaterialRequestModel model);

		Task<UpdateResponse<ApiBillOfMaterialResponseModel>> Update(int billOfMaterialsID,
		                                                             ApiBillOfMaterialRequestModel model);

		Task<ActionResponse> Delete(int billOfMaterialsID);

		Task<ApiBillOfMaterialResponseModel> Get(int billOfMaterialsID);

		Task<List<ApiBillOfMaterialResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiBillOfMaterialResponseModel> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate);

		Task<List<ApiBillOfMaterialResponseModel>> ByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b06af8b08d3c1509819ca37482568cb2</Hash>
</Codenesium>*/