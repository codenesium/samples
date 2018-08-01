using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IExtensionConfigurationRepository
	{
		Task<ExtensionConfiguration> Create(ExtensionConfiguration item);

		Task Update(ExtensionConfiguration item);

		Task Delete(string id);

		Task<ExtensionConfiguration> Get(string id);

		Task<List<ExtensionConfiguration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a35a3b7ee39d0b8a8117ff8da7d0b091</Hash>
</Codenesium>*/