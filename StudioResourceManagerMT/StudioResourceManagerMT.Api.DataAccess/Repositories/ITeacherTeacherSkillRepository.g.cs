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

		Task Delete(int id);

		Task<TeacherTeacherSkill> Get(int id);

		Task<List<TeacherTeacherSkill>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Teacher> TeacherByTeacherId(int teacherId);

		Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>79e708cef81a2c37c8cf92b159744cf4</Hash>
</Codenesium>*/