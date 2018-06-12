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

                Task<List<Feed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Feed> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>4d46905255440fa8d5eea14d2ec3e0ce</Hash>
</Codenesium>*/