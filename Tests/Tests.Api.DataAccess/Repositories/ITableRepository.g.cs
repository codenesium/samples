using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ITableRepository
	{
		Task<Table> Create(Table item);

		Task Update(Table item);

		Task Delete(int id);

		Task<Table> Get(int id);

		Task<List<Table>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1b99fb8ea6713909c669041d1ee48a0e</Hash>
</Codenesium>*/