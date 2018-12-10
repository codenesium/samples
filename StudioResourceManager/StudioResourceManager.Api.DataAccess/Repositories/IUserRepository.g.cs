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
	}
}

/*<Codenesium>
    <Hash>0767b06eadbed768c42b4d62f7a788c3</Hash>
</Codenesium>*/