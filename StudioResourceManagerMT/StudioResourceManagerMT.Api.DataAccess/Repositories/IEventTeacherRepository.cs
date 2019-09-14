using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IEventTeacherRepository
	{
		Task<EventTeacher> Create(EventTeacher item);

		Task Update(EventTeacher item);

		Task Delete(int id);

		Task<EventTeacher> Get(int id);

		Task<List<EventTeacher>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Event> EventByEventId(int eventId);

		Task<Teacher> TeacherByTeacherId(int teacherId);
	}
}

/*<Codenesium>
    <Hash>e819e49ec8464999041f6d6ae6891377</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/