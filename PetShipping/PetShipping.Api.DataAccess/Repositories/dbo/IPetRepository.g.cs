using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>79f96dc65ad1a883dcc3455ddd1c6642</Hash>
</Codenesium>*/