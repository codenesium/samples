using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceRepository
	{
		Task<Space> Create(Space item);

		Task Update(Space item);

		Task Delete(int id);

		Task<Space> Get(int id);

		Task<List<Space>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7f8cafcfd65ebcfc4e0b984fec595ffe</Hash>
</Codenesium>*/