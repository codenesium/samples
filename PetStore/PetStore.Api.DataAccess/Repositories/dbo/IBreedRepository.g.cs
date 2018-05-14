using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IBreedRepository
	{
		POCOBreed Create(ApiBreedModel model);

		void Update(int id,
		            ApiBreedModel model);

		void Delete(int id);

		POCOBreed Get(int id);

		List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c51cf92d6222b084d0d44d5e60fa365c</Hash>
</Codenesium>*/