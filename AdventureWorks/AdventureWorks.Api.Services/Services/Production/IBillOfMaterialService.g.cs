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

		Task<List<ApiBillOfMaterialResponseModel>> ByUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>25071b97d3ed94fe1edc14bc510c4453</Hash>
</Codenesium>*/