using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ITenantRepository
	{
		Task<Tenant> Create(Tenant item);

		Task Update(Tenant item);

		Task Delete(int id);

		Task<Tenant> Get(int id);

		Task<List<Tenant>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Admin>> Admins(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> Events(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventStatus>> EventStatuses(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventStudent>> EventStudents(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> EventTeachers(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Family>> Families(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> Rates(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Space>> Spaces(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceFeature>> SpaceFeatures(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceSpaceFeature>> SpaceSpaceFeatures(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> Students(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Studio>> Studios(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Teacher>> Teachers(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherSkill>> TeacherSkills(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> TeacherTeacherSkills(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> Users(int tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8a0dbd7e6e443a5e1b84e34d1b212a86</Hash>
</Codenesium>*/