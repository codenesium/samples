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

                Task<List<VariableSet>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>24de4ede7a99fad6ab0b4d7c05c19a31</Hash>
</Codenesium>*/