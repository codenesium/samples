using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IUsersService
	{
		Task<CreateResponse<ApiUsersServerResponseModel>> Create(
			ApiUsersServerRequestModel model);

		Task<UpdateResponse<ApiUsersServerResponseModel>> Update(int id,
		                                                          ApiUsersServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUsersServerResponseModel> Get(int id);

		Task<List<ApiUsersServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiBadgesServerResponseModel>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCommentsServerResponseModel>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostsServerResponseModel>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostsServerResponseModel>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVotesServerResponseModel>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostHistoryServerResponseModel>> PostHistoryByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9f1d966b917baf07e71d598a6b74f856</Hash>
</Codenesium>*/