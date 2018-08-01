using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public interface ISelfReferenceRepository
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
    <Hash>bcdd50f25a15c10c020e0fe4963b5425</Hash>
</Codenesium>*/