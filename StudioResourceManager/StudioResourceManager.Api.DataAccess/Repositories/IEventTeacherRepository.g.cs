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

		Task<List<EventTeacher>> ById(int id, int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<Event> EventById(int id);

		Task<Teacher> TeacherByTeacherId(int teacherId);
	}
}

/*<Codenesium>
    <Hash>1878562e91690cf3237c001f3531198d</Hash>
</Codenesium>*/