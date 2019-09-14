using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model);

		Task<UpdateResponse<ApiUserServerResponseModel>> Update(int id,
		                                                         ApiUserServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUserServerResponseModel> Get(int id);

		Task<List<ApiUserServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiBadgeServerResponseModel>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCommentServerResponseModel>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostServerResponseModel>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostServerResponseModel>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVoteServerResponseModel>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostHistoryServerResponseModel>> PostHistoriesByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>efda1ba9c9512357d63ec2581e216cc6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/