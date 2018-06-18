using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>157bce6636e8d6ef45da811a9172df1b</Hash>
</Codenesium>*/