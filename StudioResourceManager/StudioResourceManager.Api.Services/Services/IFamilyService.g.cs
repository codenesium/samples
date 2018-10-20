using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IFamilyService
	{
		Task<CreateResponse<ApiFamilyResponseModel>> Create(
			ApiFamilyRequestModel model);

		Task<UpdateResponse<ApiFamilyResponseModel>> Update(int id,
		                                                     ApiFamilyRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFamilyResponseModel> Get(int id);

		Task<List<ApiFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentResponseModel>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a0345f6b3611e6d1a81008fb97b698c6</Hash>
</Codenesium>*/