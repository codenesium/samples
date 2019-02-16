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

		Task<List<SelfReference>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<SelfReference>> SelfReferencesBySelfReferenceId(int selfReferenceId, int limit = int.MaxValue, int offset = 0);

		Task<List<SelfReference>> SelfReferencesBySelfReferenceId2(int selfReferenceId2, int limit = int.MaxValue, int offset = 0);

		Task<SelfReference> SelfReferenceBySelfReferenceId(int? selfReferenceId);

		Task<SelfReference> SelfReferenceBySelfReferenceId2(int? selfReferenceId2);
	}
}

/*<Codenesium>
    <Hash>051845fd108bd730608effecead196ef</Hash>
</Codenesium>*/