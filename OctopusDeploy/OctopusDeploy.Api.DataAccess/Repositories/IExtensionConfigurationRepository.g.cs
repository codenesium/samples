using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>e439feeed27f02e02047d0c98e34c383</Hash>
</Codenesium>*/