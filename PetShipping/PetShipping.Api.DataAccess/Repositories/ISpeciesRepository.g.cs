using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface ISpeciesRepository
	{
		Task<Species> Create(Species item);

		Task Update(Species item);

		Task Delete(int id);

		Task<Species> Get(int id);

		Task<List<Species>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Breed>> BreedsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>534611bb3c60e9e994c826901b6b6761</Hash>
</Codenesium>*/