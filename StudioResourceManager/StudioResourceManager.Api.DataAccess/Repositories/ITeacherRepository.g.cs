using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ITeacherRepository
	{
		Task<Teacher> Create(Teacher item);

		Task Update(Teacher item);

		Task Delete(int id);

		Task<Teacher> Get(int id);

		Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Teacher>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>b9449a1e06dd5230c3e5af9c4f93d66f</Hash>
</Codenesium>*/