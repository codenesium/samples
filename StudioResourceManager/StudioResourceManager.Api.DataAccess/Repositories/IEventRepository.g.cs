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

		Task<List<EventStudent>> EventStudents(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> EventTeachers(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<EventStatus> EventStatusByEventStatusId(int eventStatusId);

		Task<List<Event>> ByStudentId(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>942df57778619e1352570a48a633f290</Hash>
</Codenesium>*/