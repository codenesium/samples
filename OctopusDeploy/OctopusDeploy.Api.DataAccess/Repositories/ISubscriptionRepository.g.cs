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

                Task<List<Subscription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Subscription> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>7c9285084798f5ac49c5bc966701f258</Hash>
</Codenesium>*/