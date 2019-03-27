using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IEventTeacherRepository
	{
		Task<EventTeacher> Create(EventTeacher item);

		Task Update(EventTeacher item);

		Task Delete(int id);

		Task<EventTeacher> Get(int id);

		Task<List<EventTeacher>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<EventTeacher>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<Event> EventById(int id);

		Task<Teacher> TeacherByTeacherId(int teacherId);
	}
}

/*<Codenesium>
    <Hash>643827485dd371407052e6b7dca5deee</Hash>
</Codenesium>*/