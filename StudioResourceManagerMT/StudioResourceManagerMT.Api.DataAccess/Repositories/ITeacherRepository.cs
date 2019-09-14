using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface ITeacherRepository
	{
		Task<Teacher> Create(Teacher item);

		Task Update(Teacher item);

		Task Delete(int id);

		Task<Teacher> Get(int id);

		Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<EventTeacher>> EventTeachersByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherTeacherSkill>> TeacherTeacherSkillsByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>31a797b2828c139ada879c2b2f503ee2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/