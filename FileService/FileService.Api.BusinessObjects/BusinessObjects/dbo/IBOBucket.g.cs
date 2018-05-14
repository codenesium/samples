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
			ApiBucketModel model);

		Task<ActionResponse> Update(int id,
		                            ApiBucketModel model);

		Task<ActionResponse> Delete(int id);

		POCOBucket Get(int id);

		List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOBucket Name(string name);

		POCOBucket ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>e0c5453e022bbc88b757f82e67c0375d</Hash>
</Codenesium>*/