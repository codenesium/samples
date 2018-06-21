using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ILibraryVariableSetRepository
        {
                Task<LibraryVariableSet> Create(LibraryVariableSet item);

                Task Update(LibraryVariableSet item);

                Task Delete(string id);

                Task<LibraryVariableSet> Get(string id);

                Task<List<LibraryVariableSet>> All(int limit = int.MaxValue, int offset = 0);

                Task<LibraryVariableSet> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>d070619fdbb105b30ba28adb7cb67ba4</Hash>
</Codenesium>*/