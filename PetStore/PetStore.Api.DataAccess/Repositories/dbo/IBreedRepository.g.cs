using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>f0285f489adc920c7640bd6dc43c44c8</Hash>
</Codenesium>*/