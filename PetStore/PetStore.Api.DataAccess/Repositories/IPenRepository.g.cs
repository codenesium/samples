using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial interface IPenRepository
	{
		Task<Pen> Create(Pen item);

		Task Update(Pen item);

		Task Delete(int id);

		Task<Pen> Get(int id);

		Task<List<Pen>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Pet>> PetsByPenId(int penId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>75f63beedfa46168b64602217239f9b6</Hash>
</Codenesium>*/