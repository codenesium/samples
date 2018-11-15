using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IBucketService
	{
		Task<CreateResponse<ApiBucketServerResponseModel>> Create(
			ApiBucketServerRequestModel model);

		Task<UpdateResponse<ApiBucketServerResponseModel>> Update(int id,
		                                                           ApiBucketServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBucketServerResponseModel> Get(int id);

		Task<List<ApiBucketServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiBucketServerResponseModel> ByExternalId(Guid externalId);

		Task<ApiBucketServerResponseModel> ByName(string name);

		Task<List<ApiFileServerResponseModel>> FilesByBucketId(int bucketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b6ec0ca735b2113926e3f25b3768559a</Hash>
</Codenesium>*/