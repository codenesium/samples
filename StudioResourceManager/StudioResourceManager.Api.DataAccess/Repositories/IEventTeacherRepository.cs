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

		Task<List<EventTeacher>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<Event> EventByEventId(int eventId);

		Task<Teacher> TeacherByTeacherId(int teacherId);
	}
}

/*<Codenesium>
    <Hash>d28860b62728574d48da00d521f65a1f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/