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

		Task Delete(int id);

		Task<EventStudent> Get(int id);

		Task<List<EventStudent>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Event> EventByEventId(int eventId);

		Task<Student> StudentByStudentId(int studentId);
	}
}

/*<Codenesium>
    <Hash>2443db16f120cba0d8947e61f5081d54</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/