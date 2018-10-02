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

		Task<List<EventStatus>> EventStatuses(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Family>> Families(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Space>> Spaces(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceFeature>> SpaceFeatures(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Studio>> Studios(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherSkill>> TeacherSkills(int tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> Users(int tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d46df82e8adbde0ee92f5b152277afba</Hash>
</Codenesium>*/