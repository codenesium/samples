using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface ITeacherRepository
	{
		Task<Teacher> Create(Teacher item);

		Task Update(Teacher item);

		Task Delete(int id);

		Task<Teacher> Get(int id);

		Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Rate>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>2a7cf5f3124760e926b35cfaac74172a</Hash>
</Codenesium>*/