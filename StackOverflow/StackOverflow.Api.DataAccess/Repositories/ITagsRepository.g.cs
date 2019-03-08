using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ITagsRepository
	{
		Task<Tags> Create(Tags item);

		Task Update(Tags item);

		Task Delete(int id);

		Task<Tags> Get(int id);

		Task<List<Tags>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Tags>> ByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tags>> ByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);

		Task<Posts> PostsByExcerptPostId(int excerptPostId);

		Task<Posts> PostsByWikiPostId(int wikiPostId);
	}
}

/*<Codenesium>
    <Hash>9cc6e06c0a074b8ca29403a1ed9abf19</Hash>
</Codenesium>*/