using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ILibraryVariableSetRepository
        {
                Task<LibraryVariableSet> Create(LibraryVariableSet item);

                Task Update(LibraryVariableSet item);

                Task Delete(string id);

                Task<LibraryVariableSet> Get(string id);

                Task<List<LibraryVariableSet>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<LibraryVariableSet> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>8519eb768089ef2063aab3412a6c2fee</Hash>
</Codenesium>*/