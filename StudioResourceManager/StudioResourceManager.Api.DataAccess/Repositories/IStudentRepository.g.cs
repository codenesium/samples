using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IStudentRepository
	{
		Task<Student> Create(Student item);

		Task Update(Student item);

		Task Delete(int id);

		Task<Student> Get(int id);

		Task<List<Student>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<Family> FamilyByFamilyId(int familyId);

		Task<User> UserByUserId(int userId);

		Task<List<Student>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<EventStudent> CreateEventStudent(EventStudent item);

		Task DeleteEventStudent(EventStudent item);
	}
}

/*<Codenesium>
    <Hash>699b12173164e437759d0be43b0b50a9</Hash>
</Codenesium>*/