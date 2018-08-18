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

		Task<List<Password>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>42e0b83e9d7ba82e26fbb9a409ad3ca4</Hash>
</Codenesium>*/