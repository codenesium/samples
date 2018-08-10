using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IExtensionConfigurationRepository
	{
		Task<ExtensionConfiguration> Create(ExtensionConfiguration item);

		Task Update(ExtensionConfiguration item);

		Task Delete(string id);

		Task<ExtensionConfiguration> Get(string id);

		Task<List<ExtensionConfiguration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bcba2244e3273e2b43f53db237f4c163</Hash>
</Codenesium>*/