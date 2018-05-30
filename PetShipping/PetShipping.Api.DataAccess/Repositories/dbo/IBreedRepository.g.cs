using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IBreedRepository
	{
		Task<DTOBreed> Create(DTOBreed dto);

		Task Update(int id,
		            DTOBreed dto);

		Task Delete(int id);

		Task<DTOBreed> Get(int id);

		Task<List<DTOBreed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cb7cf8b8f45bf870ab4719dc8c46d380</Hash>
</Codenesium>*/