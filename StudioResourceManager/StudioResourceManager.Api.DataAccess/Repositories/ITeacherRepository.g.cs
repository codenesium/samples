using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ITeacherRepository
	{
		Task<Teacher> Create(Teacher item);

		Task Update(Teacher item);

		Task Delete(int id);

		Task<Teacher> Get(int id);

		Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> EventTeachers(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> TeacherTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);

		Task<List<Teacher>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<Teacher>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>db5e457212beb6716256fdb1fa13d5fc</Hash>
</Codenesium>*/