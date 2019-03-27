using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.DataAccess
{
	public partial interface ISubscriptionRepository
	{
		Task<Subscription> Create(Subscription item);

		Task Update(Subscription item);

		Task Delete(int id);

		Task<Subscription> Get(int id);

		Task<List<Subscription>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>93919b4f830172bb7e9cf6b8b957f004</Hash>
</Codenesium>*/