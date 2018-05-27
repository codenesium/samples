using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IAdminRepository
	{
		Task<DTOAdmin> Create(DTOAdmin dto);

		Task Update(int id,
		            DTOAdmin dto);

		Task Delete(int id);

		Task<DTOAdmin> Get(int id);

		Task<List<DTOAdmin>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8b815011197907748226a84a6125f073</Hash>
</Codenesium>*/