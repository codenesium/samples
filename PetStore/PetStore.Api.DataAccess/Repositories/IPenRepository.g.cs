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
    <Hash>b7f49f56dae2e4e306c43ef6b4b17711</Hash>
</Codenesium>*/