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
	}
}

/*<Codenesium>
    <Hash>b7aebca4bb151ebce59bdbe201561db1</Hash>
</Codenesium>*/