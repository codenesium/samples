using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ITenantService
	{
		Task<CreateResponse<ApiTenantServerResponseModel>> Create(
			ApiTenantServerRequestModel model);

		Task<UpdateResponse<ApiTenantServerResponseModel>> Update(int id,
		                                                           ApiTenantServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTenantServerResponseModel> Get(int id);

		Task<List<ApiTenantServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiAdminServerResponseModel>> AdminsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> EventsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventStatusServerResponseModel>> EventStatusByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventStudentServerResponseModel>> EventStudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherServerResponseModel>> EventTeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFamilyServerResponseModel>> FamiliesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> RatesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceServerResponseModel>> SpacesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceFeatureServerResponseModel>> SpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> SpaceSpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> StudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudioServerResponseModel>> StudiosByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherServerResponseModel>> TeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherSkillServerResponseModel>> TeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillServerResponseModel>> TeacherTeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserServerResponseModel>> UsersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>891ca92dc8bd475c8776f6f419239a01</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/