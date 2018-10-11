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

		Task Delete(int eventId);

		Task<EventTeacher> Get(int eventId);

		Task<List<EventTeacher>> All(int limit = int.MaxValue, int offset = 0);

		Task<Event> EventByEventId(int eventId);

		Task<Teacher> TeacherByTeacherId(int teacherId);
	}
}

/*<Codenesium>
    <Hash>9a10dee93b091de459a30be488fa36d2</Hash>
</Codenesium>*/