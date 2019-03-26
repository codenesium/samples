using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IEventStudentRepository
	{
		Task<EventStudent> Create(EventStudent item);

		Task Update(EventStudent item);

		Task Delete(int id);

		Task<EventStudent> Get(int id);

		Task<List<EventStudent>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<EventStudent>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventStudent>> ByStudentId(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<Event> EventByEventId(int eventId);

		Task<Student> StudentByStudentId(int studentId);
	}
}

/*<Codenesium>
    <Hash>faac99e67a58ed6532f1cae17fb47348</Hash>
</Codenesium>*/