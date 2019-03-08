using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface IPetRepository
	{
		Task<Pet> Create(Pet item);

		Task Update(Pet item);

		Task Delete(int id);

		Task<Pet> Get(int id);

		Task<List<Pet>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Breed> BreedByBreedId(int breedId);

		Task<Pen> PenByPenId(int penId);
	}
}

/*<Codenesium>
    <Hash>d0262959449f7146b29bb3a8f4f3a0d9</Hash>
</Codenesium>*/