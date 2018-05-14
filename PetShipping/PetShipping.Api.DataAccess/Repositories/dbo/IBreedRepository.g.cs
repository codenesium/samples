using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>008e29d9b0656a1aa36e459d7aa1cc2d</Hash>
</Codenesium>*/