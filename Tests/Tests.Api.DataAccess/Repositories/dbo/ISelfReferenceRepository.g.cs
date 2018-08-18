using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ISelfReferenceRepository
	{
		Task<SelfReference> Create(SelfReference item);

		Task Update(SelfReference item);

		Task Delete(int id);

		Task<SelfReference> Get(int id);

		Task<List<SelfReference>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SelfReference>> SelfReferences(int selfReferenceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>919818952598eeb626aff3bcc7017d76</Hash>
</Codenesium>*/