using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface IBreedRepository
	{
		Task<Breed> Create(Breed item);

		Task Update(Breed item);

		Task Delete(int id);

		Task<Breed> Get(int id);

		Task<List<Breed>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pet>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4b1405d39ee931b84ff9e06433186b20</Hash>
</Codenesium>*/