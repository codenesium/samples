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

		Task<List<Rate>> Rates(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> TeacherTeacherSkills(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherSkill>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3f49c9645b7f1ce6935ede307f89a17e</Hash>
</Codenesium>*/