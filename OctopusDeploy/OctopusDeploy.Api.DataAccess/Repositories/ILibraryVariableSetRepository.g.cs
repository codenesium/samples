using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ILibraryVariableSetRepository
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
    <Hash>98950de36d08fcb3084c756fe8d66d89</Hash>
</Codenesium>*/