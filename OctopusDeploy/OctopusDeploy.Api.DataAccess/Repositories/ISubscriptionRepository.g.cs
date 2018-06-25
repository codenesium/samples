using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ISubscriptionRepository
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
    <Hash>e5240f4c7e08636413f54720f49557ed</Hash>
</Codenesium>*/