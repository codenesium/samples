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
    <Hash>3faf3a872cc28b6c7a2e8a656b409c8d</Hash>
</Codenesium>*/