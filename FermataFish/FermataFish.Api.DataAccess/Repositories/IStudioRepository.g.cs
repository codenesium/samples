using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudioRepository
	{
		Task<Studio> Create(Studio item);

		Task Update(Studio item);

		Task Delete(int id);

		Task<Studio> Get(int id);

		Task<List<Studio>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d5d174aab6346f390fa91a69bccd878e</Hash>
</Codenesium>*/