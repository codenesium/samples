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

		Task<List<Sale>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0);

		Task<Breed> BreedByBreedId(int breedId);

		Task<Pen> PenByPenId(int penId);
	}
}

/*<Codenesium>
    <Hash>253b4166816d71cba766ff36328757c8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/