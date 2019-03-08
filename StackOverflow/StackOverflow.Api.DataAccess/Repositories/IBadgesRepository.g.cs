using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IBadgesRepository
	{
		Task<Badges> Create(Badges item);

		Task Update(Badges item);

		Task Delete(int id);

		Task<Badges> Get(int id);

		Task<List<Badges>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Badges>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<Users> UsersByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>18b5c173a323512f2d4853646901ff56</Hash>
</Codenesium>*/