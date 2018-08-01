using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		Task<Password> Create(Password item);

		Task Update(Password item);

		Task Delete(int businessEntityID);

		Task<Password> Get(int businessEntityID);

		Task<List<Password>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>00d22f78a6b8cd5614e0b241fa7d3f7a</Hash>
</Codenesium>*/