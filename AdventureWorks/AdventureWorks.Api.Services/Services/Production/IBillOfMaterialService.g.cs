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

		Task<List<ApiBillOfMaterialResponseModel>> ByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>182c382d6a996cadac49c58d52dd01fe</Hash>
</Codenesium>*/