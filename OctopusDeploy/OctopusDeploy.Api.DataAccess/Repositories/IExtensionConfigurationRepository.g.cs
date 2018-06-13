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

                Task<List<ExtensionConfiguration>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>ad6f9f41cad97e9ed12632bf23511b9d</Hash>
</Codenesium>*/