using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ITeacherSkillRepository
	{
		Task<TeacherSkill> Create(TeacherSkill item);

		Task Update(TeacherSkill item);

		Task Delete(int id);

		Task<TeacherSkill> Get(int id);

		Task<List<TeacherSkill>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherSkill>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8808641e48b178744440d3afe594989f</Hash>
</Codenesium>*/