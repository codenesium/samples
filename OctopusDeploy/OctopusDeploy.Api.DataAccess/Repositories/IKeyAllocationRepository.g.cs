using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IKeyAllocationRepository
	{
		Task<KeyAllocation> Create(KeyAllocation item);

		Task Update(KeyAllocation item);

		Task Delete(string collectionName);

		Task<KeyAllocation> Get(string collectionName);

		Task<List<KeyAllocation>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3389601de653a4615fe0575d101ddffe</Hash>
</Codenesium>*/