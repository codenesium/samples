using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IOctopusServerNodeRepository
	{
		Task<OctopusServerNode> Create(OctopusServerNode item);

		Task Update(OctopusServerNode item);

		Task Delete(string id);

		Task<OctopusServerNode> Get(string id);

		Task<List<OctopusServerNode>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ad4f35b305849aa0e9ad93fbbe52e63a</Hash>
</Codenesium>*/