using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IVersionInfoService
	{
		Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model);

		Task<UpdateResponse<ApiVersionInfoResponseModel>> Update(long version,
		                                                          ApiVersionInfoRequestModel model);

		Task<ActionResponse> Delete(long version);

		Task<ApiVersionInfoResponseModel> Get(long version);

		Task<List<ApiVersionInfoResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiVersionInfoResponseModel> ByVersion(long version);
	}
}

/*<Codenesium>
    <Hash>f0de0c523b666558a12e09a4ef3be58d</Hash>
</Codenesium>*/