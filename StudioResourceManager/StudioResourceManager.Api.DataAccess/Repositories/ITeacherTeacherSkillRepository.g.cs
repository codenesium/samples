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

		Task Delete(int id);

		Task<TeacherTeacherSkill> Get(int id);

		Task<List<TeacherTeacherSkill>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<Teacher> GetTeacher(int teacherId);

		Task<TeacherSkill> GetTeacherSkill(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>a16eda4f7a241e09923624d8e986509e</Hash>
</Codenesium>*/