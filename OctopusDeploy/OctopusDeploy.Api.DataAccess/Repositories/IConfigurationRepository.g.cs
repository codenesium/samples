using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IConfigurationRepository
	{
		Task<Configuration> Create(Configuration item);

		Task Update(Configuration item);

		Task Delete(string id);

		Task<Configuration> Get(string id);

		Task<List<Configuration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bdc4df9eea206c2d787ca85ff0dc7ff2</Hash>
</Codenesium>*/