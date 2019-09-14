using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IUnitOfficerService
	{
		Task<CreateResponse<ApiUnitOfficerServerResponseModel>> Create(
			ApiUnitOfficerServerRequestModel model);

		Task<UpdateResponse<ApiUnitOfficerServerResponseModel>> Update(int id,
		                                                                ApiUnitOfficerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUnitOfficerServerResponseModel> Get(int id);

		Task<List<ApiUnitOfficerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>4154532e363b540e9cf3d77522c159a5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/