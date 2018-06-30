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
    <Hash>95291406576cc531d46d5d6c3e1056be</Hash>
</Codenesium>*/