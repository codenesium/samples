using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceRepository
	{
		Task<DTOSpace> Create(DTOSpace dto);

		Task Update(int id,
		            DTOSpace dto);

		Task Delete(int id);

		Task<DTOSpace> Get(int id);

		Task<List<DTOSpace>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cca1729a1a0797bb4604082bf521be5b</Hash>
</Codenesium>*/