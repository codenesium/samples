using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IRateRepository
	{
		Task<Rate> Create(Rate item);

		Task Update(Rate item);

		Task Delete(int id);

		Task<Rate> Get(int id);

		Task<List<Rate>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Rate>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<Teacher> TeacherByTeacherId(int teacherId);

		Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>4702e733f0ddde1441da173f6cb9301c</Hash>
</Codenesium>*/