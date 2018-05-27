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
		Task<CreateResponse<ApiBucketResponseModel>> Create(
			ApiBucketRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiBucketRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBucketResponseModel> Get(int id);

		Task<List<ApiBucketResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiBucketResponseModel> GetExternalId(Guid externalId);
		Task<ApiBucketResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>b25c3fb8124e4893e6290a6ecc9767f6</Hash>
</Codenesium>*/