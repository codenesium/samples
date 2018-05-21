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

		Task<POCOBucket> Get(int id);

		Task<List<POCOBucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOBucket> Name(string name);
		Task<POCOBucket> ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>9e72617ef196cc00fb19189fdb76d6dc</Hash>
</Codenesium>*/