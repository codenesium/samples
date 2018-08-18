using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ITeacherXTeacherSkillRepository
	{
		Task<TeacherXTeacherSkill> Create(TeacherXTeacherSkill item);

		Task Update(TeacherXTeacherSkill item);

		Task Delete(int id);

		Task<TeacherXTeacherSkill> Get(int id);

		Task<List<TeacherXTeacherSkill>> All(int limit = int.MaxValue, int offset = 0);

		Task<Teacher> GetTeacher(int teacherId);

		Task<TeacherSkill> GetTeacherSkill(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>23a52c9f39607d51186d2d939b5e1462</Hash>
</Codenesium>*/