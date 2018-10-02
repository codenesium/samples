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

		Task<List<Admin>> Admins(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> Students(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Teacher>> Teachers(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f53512264f79741043eea6277629a4e3</Hash>
</Codenesium>*/