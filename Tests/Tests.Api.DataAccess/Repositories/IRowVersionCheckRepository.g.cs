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

		Task<List<RowVersionCheck>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>728d6b44c3d45bc4fd4e1f41682e7517</Hash>
</Codenesium>*/