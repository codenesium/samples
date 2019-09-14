using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ITagRepository
	{
		Task<Tag> Create(Tag item);

		Task Update(Tag item);

		Task Delete(int id);

		Task<Tag> Get(int id);

		Task<List<Tag>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Tag>> ByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tag>> ByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);

		Task<Post> PostByExcerptPostId(int excerptPostId);

		Task<Post> PostByWikiPostId(int wikiPostId);
	}
}

/*<Codenesium>
    <Hash>09a70662b36e7141c79d5f67b1229151</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/