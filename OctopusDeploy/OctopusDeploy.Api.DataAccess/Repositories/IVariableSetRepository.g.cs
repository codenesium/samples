using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>64148152e822d5265246f1d38755bfe1</Hash>
</Codenesium>*/