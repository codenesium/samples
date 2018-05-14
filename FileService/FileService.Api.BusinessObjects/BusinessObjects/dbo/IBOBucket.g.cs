using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOBucket
	{
		Task<CreateResponse<POCOBucket>> Create(
			BucketModel model);

		Task<ActionResponse> Update(int id,
		                            BucketModel model);

		Task<ActionResponse> Delete(int id);

		POCOBucket Get(int id);

		List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOBucket Name(string name);

		POCOBucket ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>bc19ed7a777e0790eb3926def843787c</Hash>
</Codenesium>*/