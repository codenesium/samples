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

                Task<List<LibraryVariableSet>> All(int limit = int.MaxValue, int offset = 0);

                Task<LibraryVariableSet> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>76157c123469c11e077d58e581726718</Hash>
</Codenesium>*/