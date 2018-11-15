using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IFamilyService
	{
		Task<CreateResponse<ApiFamilyServerResponseModel>> Create(
			ApiFamilyServerRequestModel model);

		Task<UpdateResponse<ApiFamilyServerResponseModel>> Update(int id,
		                                                           ApiFamilyServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFamilyServerResponseModel> Get(int id);

		Task<List<ApiFamilyServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8a948540ad406c72cb5048e1ec00875f</Hash>
</Codenesium>*/