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

		Task<List<TeacherTeacherSkill>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<TeacherTeacherSkill>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<Teacher> TeacherByTeacherId(int teacherId);

		Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>cafa901604906b4ff2f86ae91288b672</Hash>
</Codenesium>*/