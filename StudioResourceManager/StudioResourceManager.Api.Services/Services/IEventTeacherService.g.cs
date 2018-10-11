using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventTeacherService
	{
		Task<CreateResponse<ApiEventTeacherResponseModel>> Create(
			ApiEventTeacherRequestModel model);

		Task<UpdateResponse<ApiEventTeacherResponseModel>> Update(int eventId,
		                                                           ApiEventTeacherRequestModel model);

		Task<ActionResponse> Delete(int eventId);

		Task<ApiEventTeacherResponseModel> Get(int eventId);

		Task<List<ApiEventTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e9926c17809f67b6e78ea028fd909b85</Hash>
</Codenesium>*/