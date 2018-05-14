using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPetRepository
	{
		POCOPet Create(PetModel model);

		void Update(int id,
		            PetModel model);

		void Delete(int id);

		POCOPet Get(int id);

		List<POCOPet> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>279cb8997b3de24b643129d832a1a39e</Hash>
</Codenesium>*/