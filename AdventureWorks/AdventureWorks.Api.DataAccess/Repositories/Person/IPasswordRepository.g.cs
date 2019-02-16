using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPasswordRepository
	{
		Task<Password> Create(Password item);

		Task Update(Password item);

		Task Delete(int businessEntityID);

		Task<Password> Get(int businessEntityID);

		Task<List<Password>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>47b3e24acf1137277397cb46927074d8</Hash>
</Codenesium>*/