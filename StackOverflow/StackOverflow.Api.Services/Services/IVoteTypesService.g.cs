using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IVoteTypesService
	{
		Task<CreateResponse<ApiVoteTypesResponseModel>> Create(
			ApiVoteTypesRequestModel model);

		Task<UpdateResponse<ApiVoteTypesResponseModel>> Update(int id,
		                                                        ApiVoteTypesRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVoteTypesResponseModel> Get(int id);

		Task<List<ApiVoteTypesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5f7e87baa3830330c39849c639939e83</Hash>
</Codenesium>*/