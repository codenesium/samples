using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStateRepository
	{
		Task<DTOState> Create(DTOState dto);

		Task Update(int id,
		            DTOState dto);

		Task Delete(int id);

		Task<DTOState> Get(int id);

		Task<List<DTOState>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e20cef4c3d818f4aecef2eae8511684</Hash>
</Codenesium>*/