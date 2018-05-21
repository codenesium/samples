using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		Task<POCOSpecies> Create(ApiSpeciesModel model);

		Task Update(int id,
		            ApiSpeciesModel model);

		Task Delete(int id);

		Task<POCOSpecies> Get(int id);

		Task<List<POCOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>832839ba638b4ff54e2b122fa2f2506a</Hash>
</Codenesium>*/