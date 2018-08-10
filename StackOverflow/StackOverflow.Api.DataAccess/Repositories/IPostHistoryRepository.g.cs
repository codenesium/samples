using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostHistoryRepository
	{
		Task<PostHistory> Create(PostHistory item);

		Task Update(PostHistory item);

		Task Delete(int id);

		Task<PostHistory> Get(int id);

		Task<List<PostHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4ec257e23f6fdfb953a59fdc97276baf</Hash>
</Codenesium>*/