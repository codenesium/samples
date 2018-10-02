using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IVPersonRepository
	{
		Task<VPerson> Create(VPerson item);

		Task Update(VPerson item);

		Task Delete(int personId);

		Task<VPerson> Get(int personId);

		Task<List<VPerson>> All(int limit = int.MaxValue, int offset = 0);

		Task<VPerson> ByPersonId(int personId);
	}
}

/*<Codenesium>
    <Hash>eebcce4867b3eb65df37d7c0675a853f</Hash>
</Codenesium>*/