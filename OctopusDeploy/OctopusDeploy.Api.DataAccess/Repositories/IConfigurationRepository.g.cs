using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IConfigurationRepository
        {
                Task<Configuration> Create(Configuration item);

                Task Update(Configuration item);

                Task Delete(string id);

                Task<Configuration> Get(string id);

                Task<List<Configuration>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>5fd8a828a9558fcc4e72a14a3042730f</Hash>
</Codenesium>*/