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

		Task Delete(int eventId);

		Task<EventStudent> Get(int eventId);

		Task<List<EventStudent>> All(int limit = int.MaxValue, int offset = 0);

		Task<Event> EventByEventId(int eventId);

		Task<Student> StudentByStudentId(int studentId);
	}
}

/*<Codenesium>
    <Hash>01135a0ab69ab26484b21fbce3a9d53e</Hash>
</Codenesium>*/