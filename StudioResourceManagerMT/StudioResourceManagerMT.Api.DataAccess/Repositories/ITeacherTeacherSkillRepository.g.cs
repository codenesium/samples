using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface ITeacherTeacherSkillRepository
	{
		Task<TeacherTeacherSkill> Create(TeacherTeacherSkill item);

		Task Update(TeacherTeacherSkill item);

		Task Delete(int teacherId);

		Task<TeacherTeacherSkill> Get(int teacherId);

		Task<List<TeacherTeacherSkill>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Teacher> TeacherByTeacherId(int teacherId);

		Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>806aec5a8379f8b73a0f2d93f9bc51f8</Hash>
</Codenesium>*/