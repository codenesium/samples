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

		Task<List<EventStudent>> EventStudents(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<Family> GetFamily(int familyId);

		Task<User> GetUser(int userId);
	}
}

/*<Codenesium>
    <Hash>4dfb033bf72f8d07f75a13ceff2fefac</Hash>
</Codenesium>*/