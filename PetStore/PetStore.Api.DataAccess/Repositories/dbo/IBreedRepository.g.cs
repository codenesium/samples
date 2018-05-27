using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>09e43958c86ef816b3ec87abcd8aa1db</Hash>
</Codenesium>*/