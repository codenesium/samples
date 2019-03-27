using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IEventStudentRepository
	{
		Task<EventStudent> Create(EventStudent item);

		Task Update(EventStudent item);

		Task Delete(int eventId);

		Task<EventStudent> Get(int eventId);

		Task<List<EventStudent>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Event> EventByEventId(int eventId);

		Task<Student> StudentByStudentId(int studentId);
	}
}

/*<Codenesium>
    <Hash>3f7932188dd999528169abfebbaee119</Hash>
</Codenesium>*/