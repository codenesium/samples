using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IVPersonRepository
	{
		Task<VPerson> Get(int personId);

		Task<List<VPerson>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>776f7bc223cae91ee42f8e9bbfd3a872</Hash>
</Codenesium>*/