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
    <Hash>b5b85daf98c0b3352cc0dd4158636138</Hash>
</Codenesium>*/