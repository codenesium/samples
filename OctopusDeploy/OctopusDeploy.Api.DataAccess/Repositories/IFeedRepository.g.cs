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

                Task<List<Feed>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Feed> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>fa25a6b823d5ed04fec50ad972f72f6d</Hash>
</Codenesium>*/