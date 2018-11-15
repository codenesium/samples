using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPetRepository
	{
		Task<Pet> Create(Pet item);

		Task Update(Pet item);

		Task Delete(int id);

		Task<Pet> Get(int id);

		Task<List<Pet>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0);

		Task<Breed> BreedByBreedId(int breedId);
	}
}

/*<Codenesium>
    <Hash>dd24693c2aaedbb93f7af88ec2660038</Hash>
</Codenesium>*/