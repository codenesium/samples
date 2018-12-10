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

		Task<List<Rate>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);

		Task<List<Teacher>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<EventTeacher> CreateEventTeacher(EventTeacher item);

		Task DeleteEventTeacher(EventTeacher item);
	}
}

/*<Codenesium>
    <Hash>b413f31273dedd1eab9a567748486200</Hash>
</Codenesium>*/