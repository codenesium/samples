using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IFeedRepository
	{
		Task<Feed> Create(Feed item);

		Task Update(Feed item);

		Task Delete(string id);

		Task<Feed> Get(string id);

		Task<List<Feed>> All(int limit = int.MaxValue, int offset = 0);

		Task<Feed> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>b92556a64b5e541d309bdadc67f9d9b8</Hash>
</Codenesium>*/