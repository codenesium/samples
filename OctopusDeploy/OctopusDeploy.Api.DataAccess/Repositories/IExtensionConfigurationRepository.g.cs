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

                Task<List<ExtensionConfiguration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4fcff092fc62063e12f21e9df3dcc186</Hash>
</Codenesium>*/