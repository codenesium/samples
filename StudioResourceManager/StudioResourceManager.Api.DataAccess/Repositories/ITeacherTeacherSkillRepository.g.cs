using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ITeacherTeacherSkillRepository
	{
		Task<TeacherTeacherSkill> Create(TeacherTeacherSkill item);

		Task Update(TeacherTeacherSkill item);

		Task Delete(int teacherId);

		Task<TeacherTeacherSkill> Get(int teacherId);

		Task<List<TeacherTeacherSkill>> All(int limit = int.MaxValue, int offset = 0);

		Task<Teacher> TeacherByTeacherId(int teacherId);

		Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>818e64cd9e4541a4747db2932cc42d37</Hash>
</Codenesium>*/