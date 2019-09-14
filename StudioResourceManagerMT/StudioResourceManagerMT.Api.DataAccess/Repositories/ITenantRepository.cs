using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface ITenantRepository
	{
		Task<Tenant> Create(Tenant item);

		Task Update(Tenant item);

		Task Delete(int id);

		Task<Tenant> Get(int id);

		Task<List<Tenant>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Admin>> AdminsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> EventsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventStatus>> EventStatusByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventStudent>> EventStudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> EventTeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Family>> FamiliesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> RatesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Space>> SpacesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceFeature>> SpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceSpaceFeature>> SpaceSpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> StudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Studio>> StudiosByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Teacher>> TeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherSkill>> TeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> TeacherTeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> UsersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d4a5ac08d618a242f037997a67a315cf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/