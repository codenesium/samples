using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IVariableSetRepository
        {
                Task<VariableSet> Create(VariableSet item);

                Task Update(VariableSet item);

                Task Delete(string id);

                Task<VariableSet> Get(string id);

                Task<List<VariableSet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e9d4efbe1da33b18c545f2358da6662a</Hash>
</Codenesium>*/