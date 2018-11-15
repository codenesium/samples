using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBillOfMaterialService
	{
		Task<CreateResponse<ApiBillOfMaterialServerResponseModel>> Create(
			ApiBillOfMaterialServerRequestModel model);

		Task<UpdateResponse<ApiBillOfMaterialServerResponseModel>> Update(int billOfMaterialsID,
		                                                                   ApiBillOfMaterialServerRequestModel model);

		Task<ActionResponse> Delete(int billOfMaterialsID);

		Task<ApiBillOfMaterialServerResponseModel> Get(int billOfMaterialsID);

		Task<List<ApiBillOfMaterialServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBillOfMaterialServerResponseModel>> ByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2bcc78aa908fb0b5b551ddd46623c9b8</Hash>
</Codenesium>*/