using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPetRepository
	{
		Task<Pet> Create(Pet item);

		Task Update(Pet item);

		Task Delete(int id);

		Task<Pet> Get(int id);

		Task<List<Pet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf30f01e0f60ab3b7ca016423f56d423</Hash>
</Codenesium>*/