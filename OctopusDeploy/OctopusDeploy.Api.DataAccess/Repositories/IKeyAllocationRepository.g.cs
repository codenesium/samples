using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IKeyAllocationRepository
	{
		Task<KeyAllocation> Create(KeyAllocation item);

		Task Update(KeyAllocation item);

		Task Delete(string collectionName);

		Task<KeyAllocation> Get(string collectionName);

		Task<List<KeyAllocation>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f26dae7ad839d8cd2a9e6ea5a85ea476</Hash>
</Codenesium>*/