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

                Task<List<Subscription>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Subscription> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>746fadd68ff8f32af24f729e71545b05</Hash>
</Codenesium>*/