using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IReplyRepository
	{
		Task<Reply> Create(Reply item);

		Task Update(Reply item);

		Task Delete(int replyId);

		Task<Reply> Get(int replyId);

		Task<List<Reply>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Reply>> ByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<User> GetUser(int replierUserId);
	}
}

/*<Codenesium>
    <Hash>99e10f01f77049644d8e0de4f13e4b97</Hash>
</Codenesium>*/