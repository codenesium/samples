using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IEventRepository
	{
		Task<Event> Create(Event item);

		Task Update(Event item);

		Task Delete(int id);

		Task<Event> Get(int id);

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<EventStudent>> EventStudentsByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> EventTeachersByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<EventStatu> EventStatuByEventStatusId(int eventStatusId);
	}
}

/*<Codenesium>
    <Hash>81f27ccd44fc8c17d1627bedaa9b6a17</Hash>
</Codenesium>*/