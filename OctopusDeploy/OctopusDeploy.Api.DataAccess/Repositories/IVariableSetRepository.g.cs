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

                Task<List<VariableSet>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>fc8170e8c2e6660e4903802c3092f7bb</Hash>
</Codenesium>*/