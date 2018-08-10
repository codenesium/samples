using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ICommentsService
	{
		Task<CreateResponse<ApiCommentsResponseModel>> Create(
			ApiCommentsRequestModel model);

		Task<UpdateResponse<ApiCommentsResponseModel>> Update(int id,
		                                                       ApiCommentsRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCommentsResponseModel> Get(int id);

		Task<List<ApiCommentsResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>45806071ade3971bdd1d834925328017</Hash>
</Codenesium>*/