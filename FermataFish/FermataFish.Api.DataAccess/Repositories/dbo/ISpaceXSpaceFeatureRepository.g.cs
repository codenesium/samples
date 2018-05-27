using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
	{
		Task<DTOSpaceXSpaceFeature> Create(DTOSpaceXSpaceFeature dto);

		Task Update(int id,
		            DTOSpaceXSpaceFeature dto);

		Task Delete(int id);

		Task<DTOSpaceXSpaceFeature> Get(int id);

		Task<List<DTOSpaceXSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c5b13611d9583d82cc26a179e8999c7e</Hash>
</Codenesium>*/