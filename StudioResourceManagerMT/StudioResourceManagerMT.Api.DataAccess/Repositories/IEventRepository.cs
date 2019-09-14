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

		Task<EventStatus> EventStatusByEventStatusId(int eventStatusId);
	}
}

/*<Codenesium>
    <Hash>7414aa58cf19f2560887f70a9869adf4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/