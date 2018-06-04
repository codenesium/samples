using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
	public interface IFileTypeService
	{
		Task<CreateResponse<ApiFileTypeResponseModel>> Create(
			ApiFileTypeRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFileTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFileTypeResponseModel> Get(int id);

		Task<List<ApiFileTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5bf007fc25a4f61c19471f9093f8564a</Hash>
</Codenesium>*/