using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
	public interface IFileService
	{
		Task<CreateResponse<ApiFileResponseModel>> Create(
			ApiFileRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFileRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFileResponseModel> Get(int id);

		Task<List<ApiFileResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>92d2eb83fdc5ff98f82c6161e149c18f</Hash>
</Codenesium>*/