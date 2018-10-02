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

		Task<List<Teacher>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> TeacherTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<User> GetUser(int userId);
	}
}

/*<Codenesium>
    <Hash>0ba7df42c1cfdfc7c25d0ba41dee825b</Hash>
</Codenesium>*/