using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IBreedRepository
	{
		POCOBreed Create(BreedModel model);

		void Update(int id,
		            BreedModel model);

		void Delete(int id);

		POCOBreed Get(int id);

		List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>17209e0df5cfd720099d466de8134b42</Hash>
</Codenesium>*/