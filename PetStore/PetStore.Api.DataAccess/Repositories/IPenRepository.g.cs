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

		Task<List<Pen>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pet>> Pets(int penId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2494c50bf777c1d509ad8c640ef41c78</Hash>
</Codenesium>*/