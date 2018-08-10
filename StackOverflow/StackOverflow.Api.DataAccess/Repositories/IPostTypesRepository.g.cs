using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostTypesRepository
	{
		Task<PostTypes> Create(PostTypes item);

		Task Update(PostTypes item);

		Task Delete(int id);

		Task<PostTypes> Get(int id);

		Task<List<PostTypes>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a732caf7d29e26dc26d1c3a5e10b1140</Hash>
</Codenesium>*/