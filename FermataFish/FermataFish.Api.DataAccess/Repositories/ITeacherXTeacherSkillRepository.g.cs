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

		Task<List<TeacherXTeacherSkill>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<Teacher> GetTeacher(int teacherId);

		Task<TeacherSkill> GetTeacherSkill(int teacherSkillId);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>9701a84cede76560fda1f321f9be871f</Hash>
</Codenesium>*/