using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public interface IRowVersionCheckRepository
	{
		Task<RowVersionCheck> Create(RowVersionCheck item);

		Task Update(RowVersionCheck item);

		Task Delete(int id);

		Task<RowVersionCheck> Get(int id);

		Task<List<RowVersionCheck>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b73d16d1f68d692ca4a76962b622ade6</Hash>
</Codenesium>*/