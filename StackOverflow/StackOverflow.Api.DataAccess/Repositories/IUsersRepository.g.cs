using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IUsersRepository
	{
		Task<Users> Create(Users item);

		Task Update(Users item);

		Task Delete(int id);

		Task<Users> Get(int id);

		Task<List<Users>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Badges>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Comments>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<Posts>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Posts>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Votes>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostHistory>> PostHistoryByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ada4f49a8bec90009637e828d0d879b5</Hash>
</Codenesium>*/