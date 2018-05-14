using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPetRepository
	{
		POCOPet Create(ApiPetModel model);

		void Update(int id,
		            ApiPetModel model);

		void Delete(int id);

		POCOPet Get(int id);

		List<POCOPet> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>da6178c43c85be982689d70726358296</Hash>
</Codenesium>*/