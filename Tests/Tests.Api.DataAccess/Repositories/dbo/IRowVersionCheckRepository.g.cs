using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IRowVersionCheckRepository
	{
		Task<RowVersionCheck> Create(RowVersionCheck item);

		Task Update(RowVersionCheck item);

		Task Delete(int id);

		Task<RowVersionCheck> Get(int id);

		Task<List<RowVersionCheck>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>269278b64ccd47d5b1911a49c0713577</Hash>
</Codenesium>*/