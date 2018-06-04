using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>4c6683d374cd8dba07d46128dc4e48b4</Hash>
</Codenesium>*/