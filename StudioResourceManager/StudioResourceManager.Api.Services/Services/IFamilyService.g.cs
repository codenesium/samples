using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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

		Task<List<ApiFamilyServerResponseModel>> ByUserId(int familyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b2a516465afc2bd263ba112bf63826a6</Hash>
</Codenesium>*/