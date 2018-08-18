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
    <Hash>f1403094027d5adf83c27fc5b1ff45dd</Hash>
</Codenesium>*/