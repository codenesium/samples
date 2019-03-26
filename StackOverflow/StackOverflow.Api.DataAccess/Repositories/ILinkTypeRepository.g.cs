using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ILinkTypeRepository
	{
		Task<LinkType> Create(LinkType item);

		Task Update(LinkType item);

		Task Delete(int id);

		Task<LinkType> Get(int id);

		Task<List<LinkType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PostLink>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>69c833e315a948bf2266d14a84f537c6</Hash>
</Codenesium>*/