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

		Task<List<EventTeacher>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<EventTeacher>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<Event> GetEvent(int eventId);
	}
}

/*<Codenesium>
    <Hash>db27b5bd44755630afc6a5170e793e0e</Hash>
</Codenesium>*/