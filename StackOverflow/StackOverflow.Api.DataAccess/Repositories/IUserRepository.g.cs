using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IUserRepository
	{
		Task<User> Create(User item);

		Task Update(User item);

		Task Delete(int id);

		Task<User> Get(int id);

		Task<List<User>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Badge>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Comment>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Post>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Post>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Vote>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostHistory>> PostHistoriesByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6e7ac4359913e86baae6dca615ff6629</Hash>
</Codenesium>*/