using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICultureRepository
	{
		Task<Culture> Create(Culture item);

		Task Update(Culture item);

		Task Delete(string cultureID);

		Task<Culture> Get(string cultureID);

		Task<List<Culture>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Culture> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>138aa670f07b2dd2959b1e5ff4922395</Hash>
</Codenesium>*/