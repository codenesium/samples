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

                Task<List<LibraryVariableSet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<LibraryVariableSet> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>a5ccfc5f978660739458a1bf7948f1c6</Hash>
</Codenesium>*/