using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IStudioService
	{
		Task<CreateResponse<ApiStudioResponseModel>> Create(
			ApiStudioRequestModel model);

		Task<UpdateResponse<ApiStudioResponseModel>> Update(int id,
		                                                     ApiStudioRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudioResponseModel> Get(int id);

		Task<List<ApiStudioResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f93060c353860b958f897c0cb6948b18</Hash>
</Codenesium>*/