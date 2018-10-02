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

		Task<List<EventStudent>> All(int limit = int.MaxValue, int offset = 0);

		Task<Event> GetEvent(int eventId);

		Task<Student> GetStudent(int studentId);
	}
}

/*<Codenesium>
    <Hash>0be8b7d54d574d5faaaada284197f85e</Hash>
</Codenesium>*/