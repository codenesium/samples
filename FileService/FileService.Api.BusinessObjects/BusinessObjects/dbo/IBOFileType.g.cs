using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOFileType
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
    <Hash>b8ec46293809662f12e374a6746e63c6</Hash>
</Codenesium>*/