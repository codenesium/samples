using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITenantService
	{
		Task<CreateResponse<ApiTenantResponseModel>> Create(
			ApiTenantRequestModel model);

		Task<UpdateResponse<ApiTenantResponseModel>> Update(int id,
		                                                     ApiTenantRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTenantResponseModel> Get(int id);

		Task<List<ApiTenantResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiAdminResponseModel>> AdminsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventResponseModel>> EventsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventStatusResponseModel>> EventStatusesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFamilyResponseModel>> FamiliesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateResponseModel>> RatesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceResponseModel>> SpacesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceFeatureResponseModel>> SpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentResponseModel>> StudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudioResponseModel>> StudiosByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherResponseModel>> TeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherSkillResponseModel>> TeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> UsersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>974ee8f2e9b04e9a5bfbbe63435c1f94</Hash>
</Codenesium>*/