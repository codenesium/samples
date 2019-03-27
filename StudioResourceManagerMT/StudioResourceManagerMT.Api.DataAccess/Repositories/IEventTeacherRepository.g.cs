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

		Task Delete(int eventId);

		Task<EventTeacher> Get(int eventId);

		Task<List<EventTeacher>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Event> EventByEventId(int eventId);

		Task<Teacher> TeacherByTeacherId(int teacherId);
	}
}

/*<Codenesium>
    <Hash>3d554c0ca6edd228db3c967fd98d555c</Hash>
</Codenesium>*/