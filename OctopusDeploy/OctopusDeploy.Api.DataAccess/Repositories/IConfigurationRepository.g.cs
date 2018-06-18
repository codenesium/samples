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

                Task<List<Configuration>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5f365fcd36bd481c60327715b64449a4</Hash>
</Codenesium>*/