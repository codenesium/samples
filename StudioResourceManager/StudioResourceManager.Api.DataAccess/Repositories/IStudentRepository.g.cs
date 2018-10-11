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

		Task<List<EventStudent>> EventStudents(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<Family> FamilyByFamilyId(int familyId);

		Task<User> UserByUserId(int userId);

		Task<List<Student>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>11592102948feba93e48f89e5a0a4f2e</Hash>
</Codenesium>*/