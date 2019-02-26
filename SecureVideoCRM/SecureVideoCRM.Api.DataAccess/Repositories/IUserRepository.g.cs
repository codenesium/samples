using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.DataAccess
{
	public partial interface IUserRepository
	{
		Task<User> Create(User item);

		Task Update(User item);

		Task Delete(int id);

		Task<User> Get(int id);

		Task<List<User>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<User>> BySubscriptionId(int subscriptionId, int limit = int.MaxValue, int offset = 0);

		Task<Subscription> SubscriptionBySubscriptionId(int subscriptionId);
	}
}

/*<Codenesium>
    <Hash>33c117268697dc322681ebd079c97924</Hash>
</Codenesium>*/