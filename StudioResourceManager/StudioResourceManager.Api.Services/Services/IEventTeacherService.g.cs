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

		Task<UpdateResponse<ApiEventTeacherResponseModel>> Update(int id,
		                                                           ApiEventTeacherRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventTeacherResponseModel> Get(int id);

		Task<List<ApiEventTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherResponseModel>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b63892871834133e8aa0e4e09b764d8e</Hash>
</Codenesium>*/