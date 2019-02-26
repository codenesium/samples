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

		Task<List<User>> UsersBySubscriptionId(int subscriptionId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f6f25176779637589b2a3f540b798b0e</Hash>
</Codenesium>*/