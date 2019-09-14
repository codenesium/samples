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

		Task<List<Reply>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Reply>> ByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByReplierUserId(int replierUserId);
	}
}

/*<Codenesium>
    <Hash>9b3cff160434f4f81229eca47875c6eb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/