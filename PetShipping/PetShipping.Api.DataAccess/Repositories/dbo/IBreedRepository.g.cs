using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IBreedRepository
	{
		Task<POCOBreed> Create(ApiBreedModel model);

		Task Update(int id,
		            ApiBreedModel model);

		Task Delete(int id);

		Task<POCOBreed> Get(int id);

		Task<List<POCOBreed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>291790581cc9c4096a94474359e199df</Hash>
</Codenesium>*/