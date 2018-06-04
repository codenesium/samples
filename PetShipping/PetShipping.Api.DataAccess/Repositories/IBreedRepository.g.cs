using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IBreedRepository
	{
		Task<Breed> Create(Breed item);

		Task Update(Breed item);

		Task Delete(int id);

		Task<Breed> Get(int id);

		Task<List<Breed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4ce212a04b89127234057e91e3503b3c</Hash>
</Codenesium>*/