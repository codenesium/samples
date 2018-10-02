using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IColumnSameAsFKTableRepository
	{
		Task<ColumnSameAsFKTable> Create(ColumnSameAsFKTable item);

		Task Update(ColumnSameAsFKTable item);

		Task Delete(int id);

		Task<ColumnSameAsFKTable> Get(int id);

		Task<List<ColumnSameAsFKTable>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>64e15ffe387509bc648d811f31d2702a</Hash>
</Codenesium>*/