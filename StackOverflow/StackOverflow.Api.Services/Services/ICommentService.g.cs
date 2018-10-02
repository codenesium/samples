using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ICommentService
	{
		Task<CreateResponse<ApiCommentResponseModel>> Create(
			ApiCommentRequestModel model);

		Task<UpdateResponse<ApiCommentResponseModel>> Update(int id,
		                                                      ApiCommentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCommentResponseModel> Get(int id);

		Task<List<ApiCommentResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fa6207d91e041bffb4d57ddbfaf956b1</Hash>
</Codenesium>*/