using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>1e5c5954463e5214ab4578295c6f0812</Hash>
</Codenesium>*/