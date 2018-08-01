using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IConfigurationRepository
	{
		Task<Configuration> Create(Configuration item);

		Task Update(Configuration item);

		Task Delete(string id);

		Task<Configuration> Get(string id);

		Task<List<Configuration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>609f6011e29ca5f5a5b6ea136114f339</Hash>
</Codenesium>*/