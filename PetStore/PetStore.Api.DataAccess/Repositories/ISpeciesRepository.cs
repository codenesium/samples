using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface ISpeciesRepository
	{
		Task<Species> Create(Species item);

		Task Update(Species item);

		Task Delete(int id);

		Task<Species> Get(int id);

		Task<List<Species>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Breed>> BreedsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>054bd5fe4cb0fc5a428564aeaeec31a6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/