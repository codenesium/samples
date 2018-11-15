using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IUserRepository
	{
		Task<User> Create(User item);

		Task Update(User item);

		Task Delete(int id);

		Task<User> Get(int id);

		Task<List<User>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Admin>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Teacher>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<Student> CreateStudent(Student item);

		Task DeleteStudent(Student item);
	}
}

/*<Codenesium>
    <Hash>bbf41f00bcf8e610d90aabdaaec6c5a9</Hash>
</Codenesium>*/