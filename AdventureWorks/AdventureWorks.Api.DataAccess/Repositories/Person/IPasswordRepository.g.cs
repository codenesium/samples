using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		Task<Password> Create(Password item);

		Task Update(Password item);

		Task Delete(int businessEntityID);

		Task<Password> Get(int businessEntityID);

		Task<List<Password>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4475df4a3f6f1add402b6e42e3154084</Hash>
</Codenesium>*/