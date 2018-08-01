using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherXTeacherSkillRepository
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
    <Hash>3a68b8fb06ff31408e35fda304832cbe</Hash>
</Codenesium>*/