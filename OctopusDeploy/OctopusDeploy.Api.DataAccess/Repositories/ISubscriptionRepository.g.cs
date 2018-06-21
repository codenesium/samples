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

                Task<Subscription> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>1c513e67bbfeb734b8910c81f482e88e</Hash>
</Codenesium>*/