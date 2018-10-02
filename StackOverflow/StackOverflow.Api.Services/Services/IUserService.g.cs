using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserResponseModel>> Create(
			ApiUserRequestModel model);

		Task<UpdateResponse<ApiUserResponseModel>> Update(int id,
		                                                   ApiUserRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUserResponseModel> Get(int id);

		Task<List<ApiUserResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0720952f4fa2788cfe6ebb47fb840c4d</Hash>
</Codenesium>*/