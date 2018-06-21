using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IFeedRepository
        {
                Task<Feed> Create(Feed item);

                Task Update(Feed item);

                Task Delete(string id);

                Task<Feed> Get(string id);

                Task<List<Feed>> All(int limit = int.MaxValue, int offset = 0);

                Task<Feed> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>185d43c2f551e41e6762c9590b4745c3</Hash>
</Codenesium>*/