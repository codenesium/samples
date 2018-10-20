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

		Task<List<Pet>> PetsByPenId(int penId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d793beeab9ca264510327e8a82c8bdf2</Hash>
</Codenesium>*/