using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.DataAccess
{
	public partial interface IVideoRepository
	{
		Task<Video> Create(Video item);

		Task Update(Video item);

		Task Delete(int id);

		Task<Video> Get(int id);

		Task<List<Video>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>dc4139ee8143a58aaa05a41c7a512808</Hash>
</Codenesium>*/