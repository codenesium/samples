using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ISubscriptionRepository
	{
		Task<Subscription> Create(Subscription item);

		Task Update(Subscription item);

		Task Delete(string id);

		Task<Subscription> Get(string id);

		Task<List<Subscription>> All(int limit = int.MaxValue, int offset = 0);

		Task<Subscription> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>1088091ee1e257bbd89db4cae253a8b7</Hash>
</Codenesium>*/