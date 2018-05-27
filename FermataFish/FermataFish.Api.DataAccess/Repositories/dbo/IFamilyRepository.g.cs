using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IFamilyRepository
	{
		Task<DTOFamily> Create(DTOFamily dto);

		Task Update(int id,
		            DTOFamily dto);

		Task Delete(int id);

		Task<DTOFamily> Get(int id);

		Task<List<DTOFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e2d2ca60363430c0b7fc4e0e6310044</Hash>
</Codenesium>*/