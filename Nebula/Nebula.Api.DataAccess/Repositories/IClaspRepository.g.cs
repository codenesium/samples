using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		Task<Clasp> Create(Clasp item);

		Task Update(Clasp item);

		Task Delete(int id);

		Task<Clasp> Get(int id);

		Task<List<Clasp>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1b225b15732a994a776b98de71822e55</Hash>
</Codenesium>*/