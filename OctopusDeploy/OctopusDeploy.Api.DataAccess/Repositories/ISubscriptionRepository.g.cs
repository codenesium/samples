using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<Subscription> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>5a9907c41b91f5beaae702e2f9ec7d82</Hash>
</Codenesium>*/