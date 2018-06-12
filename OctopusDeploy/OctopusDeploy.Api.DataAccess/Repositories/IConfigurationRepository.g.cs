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

                Task<List<Configuration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3d91fc9e96733882648a73803c7c2146</Hash>
</Codenesium>*/