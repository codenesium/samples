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

                Task<LibraryVariableSet> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>2865392b81b5ecb8848a070318935af1</Hash>
</Codenesium>*/