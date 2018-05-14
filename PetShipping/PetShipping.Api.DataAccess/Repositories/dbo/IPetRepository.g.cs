using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>1f07a68b42c6e519642922d8e00a9348</Hash>
</Codenesium>*/