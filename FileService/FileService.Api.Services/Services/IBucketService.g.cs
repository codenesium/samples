using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public interface IBucketService
	{
		Task<CreateResponse<ApiBucketResponseModel>> Create(
			ApiBucketRequestModel model);

		Task<UpdateResponse<ApiBucketResponseModel>> Update(int id,
		                                                     ApiBucketRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBucketResponseModel> Get(int id);

		Task<List<ApiBucketResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiBucketResponseModel> ByExternalId(Guid externalId);

		Task<ApiBucketResponseModel> ByName(string name);

		Task<List<ApiFileResponseModel>> Files(int bucketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c472ebb26b50dcd3154b7e9c7d10706c</Hash>
</Codenesium>*/