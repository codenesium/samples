using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		Task<DTORate> Create(DTORate dto);

		Task Update(int id,
		            DTORate dto);

		Task Delete(int id);

		Task<DTORate> Get(int id);

		Task<List<DTORate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a9bfd3a1b8f30266011a3b6367016057</Hash>
</Codenesium>*/