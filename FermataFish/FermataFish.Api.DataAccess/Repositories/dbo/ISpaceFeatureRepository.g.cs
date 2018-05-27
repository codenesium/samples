using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceFeatureRepository
	{
		Task<DTOSpaceFeature> Create(DTOSpaceFeature dto);

		Task Update(int id,
		            DTOSpaceFeature dto);

		Task Delete(int id);

		Task<DTOSpaceFeature> Get(int id);

		Task<List<DTOSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>603de81bcf0d5eef345b4a6369343166</Hash>
</Codenesium>*/