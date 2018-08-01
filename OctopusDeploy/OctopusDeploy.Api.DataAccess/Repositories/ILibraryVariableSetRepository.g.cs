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
    <Hash>1fb7507d7f6c069f58f87b0cc75f16ad</Hash>
</Codenesium>*/