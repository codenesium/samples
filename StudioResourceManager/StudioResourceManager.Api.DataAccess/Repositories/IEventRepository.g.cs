using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IEventRepository
	{
		Task<Event> Create(Event item);

		Task Update(Event item);

		Task Delete(int id);

		Task<Event> Get(int id);

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);

		Task<EventStatu> EventStatuByEventStatusId(int eventStatusId);

		Task<List<Event>> ByStudentId(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<EventStudent> CreateEventStudent(EventStudent item);

		Task DeleteEventStudent(EventStudent item);

		Task<List<Event>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<EventTeacher> CreateEventTeacher(EventTeacher item);

		Task DeleteEventTeacher(EventTeacher item);
	}
}

/*<Codenesium>
    <Hash>8254f7c3cf8fbbce291d660a6bef44c9</Hash>
</Codenesium>*/